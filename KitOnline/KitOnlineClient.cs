using System;
using System.Net.Http;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;
using KitOnline.Enums;
using KitOnline.Models;
using KitOnline.Models.SendCheck;
using Newtonsoft.Json;
using Refit;

[assembly: InternalsVisibleTo("KitOnline.Test")]

namespace KitOnline
{
    public class KitOnlineClient
    {
        private const string DefaultHost = "https://api.kit-invest.ru";
        private const long ResultOk = 0;

        private readonly KitOnlineAuthorization _authorization;

        private readonly IKitOnlineClient _client;
        private readonly bool _requireFiscalData;
        private readonly bool _requireLink;

        public KitOnlineClient(
            string login,
            string password,
            int companyId,
            bool requireLink = false,
            bool requireFiscalData = false,
            string host = DefaultHost)
            : this(new KitOnlineAuthorization(login, password, companyId),
                requireLink,
                requireFiscalData,
                host)
        {
        }

        public KitOnlineClient(
            in KitOnlineAuthorization authorization,
            bool requireLink = false,
            bool requireFiscalData = false,
            string host = DefaultHost)
        {
            _authorization = authorization;
            _requireLink = requireLink; //ссылка возвращается только если включен requireFiscalData
            _requireFiscalData = requireLink || requireFiscalData;
            _client = CreateClient(host);
        }

        /// <summary> Дефолтный таймаут отправки чека и ожидания результата </summary>
        public TimeSpan DefaultTimeout { get; set; } = TimeSpan.FromMinutes(5);

        /// <summary>
        ///     Отправляет чек без проверки состояния чека и результата отправки, соответственно
        ///     Для проверки состояния чека необходимо вызвать <see cref="StateCheck" />
        /// </summary>
        /// <remarks>
        ///     Рекомендуется использовать сразу <see cref="SendCheckAndWaitResult" />
        /// </remarks>
        public Task<ResponseBody> SendCheck(
            Check check, CancellationToken cancellationToken = default)
        {
            if (check == null) throw new ArgumentNullException(nameof(check));
            if (check.Pay == null) throw new NullReferenceException(nameof(check.Pay));

            var request = new RequestBody(CreateRequest(check.CheckId), check);
            return _client.SendCheck(request, cancellationToken);
        }

        /// <summary>
        ///     Проверяет состояние чека по id чека, полученному после вызова <see cref="SendCheck" />
        /// </summary>
        /// <seealso cref="SendCheckAndWaitResult" />
        public Task<Models.StateCheck.ResponseBody> StateCheck(
            string checkId, CancellationToken cancellationToken = default)
        {
            if (checkId == null) throw new ArgumentNullException(nameof(checkId));
            var request = new Models.StateCheck.RequestBody(CreateRequest(checkId), checkId);
            return _client.StateCheck(request, cancellationToken);
        }

        /// <summary>
        ///     Отправляет чек и дожидается его обработки
        ///     Важно: Может выполняться продолжительное время
        /// </summary>
        /// <param name="check">Чек на отправку</param>
        /// <param name="cancellationToken">Токен, предоставляющий возможность отмены операции</param>
        /// <returns>
        ///     Структуру <see cref="SendCheckResultOrException" />, содержащую:
        ///     ответ на команду отправки чека, ответ на команду о состоянии чека или исключение в случае ошибки
        /// </returns>
        public async Task<SendCheckResultOrException> SendCheckAndWaitResult(
            Check check, CancellationToken cancellationToken = default)
        {
            if (check == null) throw new ArgumentNullException(nameof(check));
            if (check.CheckId == null) throw new ArgumentNullException(nameof(Check.CheckId));
            if (cancellationToken == default)
            {
                cancellationToken = new CancellationTokenSource(DefaultTimeout).Token;
            }
            ResponseBody? sendCheckResponse = null;
            Models.StateCheck.ResponseBody? stateCheckResponse = null;
            try
            {
                sendCheckResponse = await SendCheck(check, cancellationToken).ConfigureAwait(false);
                if (sendCheckResponse.ResultCode != ResultOk)
                {
                    return new SendCheckResultOrException(sendCheckResponse);
                }

                do
                {
                    cancellationToken.ThrowIfCancellationRequested();
                    await Task.Delay(TimeSpan.FromSeconds(2), cancellationToken).ConfigureAwait(false);
                    stateCheckResponse = await StateCheck(check.CheckId, cancellationToken).ConfigureAwait(false);
                } while (stateCheckResponse.CheckState?.State <= CheckStateEnum.FixationInKKT);
            }
            catch (Exception e)
            {
                return new SendCheckResultOrException(sendCheckResponse, stateCheckResponse, e);
            }

            return new SendCheckResultOrException(sendCheckResponse, stateCheckResponse);
        }

        /// <summary>
        ///     Создает подписанный запрос по заданному <paramref name="checkId" />
        /// </summary>
        internal Request CreateRequest(string checkId)
        {
            if (checkId == null) throw new ArgumentNullException(nameof(checkId));
            return new Request(_authorization.CompanyId, _authorization.Login, GetSign(checkId), _requireLink,
                _requireFiscalData);
        }

        /// <summary>
        ///     Создает подпись из заданного <paramref name="checkId" />
        /// </summary>
        internal string GetSign(string checkId)
        {
            if (checkId == null) throw new ArgumentNullException(nameof(checkId));
            return $"{_authorization.CompanyId}{_authorization.Password}{checkId}".Md5();
        }

        private static IKitOnlineClient CreateClient(string host)
        {
            var httpClient = new HttpClient
            {
                BaseAddress = new Uri(host),
                Timeout = TimeSpan.FromSeconds(60)
            };

            return RestService.For<IKitOnlineClient>(httpClient, new RefitSettings
            {
                ContentSerializer = new NewtonsoftJsonContentSerializer(GetJsonSerializerSettings())
            });
        }

        internal static JsonSerializerSettings GetJsonSerializerSettings()
        {
            return new JsonSerializerSettings
            {
                NullValueHandling = NullValueHandling.Ignore
            };
        }
    }
}