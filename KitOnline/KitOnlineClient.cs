using System;
using System.Net.Http;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;
using KitOnline.Enums;
using KitOnline.Models;
using Newtonsoft.Json;
using Refit;

[assembly: InternalsVisibleTo("KitOnline.Test")]

namespace KitOnline
{
	public class KitOnlineClient
	{
		private const string HostUrl = "https://api.kit-invest.ru";

		private readonly IKitOnlineClient _client = Create();

		private readonly KitOnlineAuthorization _authorization;
		private readonly bool _requireLink;
		private readonly bool _requireFiscalData;

		public KitOnlineClient(string login, string password, int companyId, 
			bool requireLink = false, bool requireFiscalData = false) 
			: this(new KitOnlineAuthorization(login, password, companyId), requireLink, requireFiscalData)
		{}
		
		public KitOnlineClient(in KitOnlineAuthorization authorization, bool requireLink = false, bool requireFiscalData = false)
		{
			_authorization = authorization;
			_requireLink = requireLink; //ссылка возвращается только если включен requireFiscalData
			_requireFiscalData = requireLink || requireFiscalData;
		}

		/// <summary>
		/// Отправляет чек без проверки состояния чека и результата отправки, соответственно
		/// Для проверки состояния чека необходимо вызвать <see cref="StateCheck"/>
		/// </summary>
		/// <remarks>
		///	Рекомендуется использовать сразу <see cref="SendCheckAndWaitResult"/>
		/// </remarks>
		public Task<Models.SendCheck.ResponseBody> SendCheck(Check check, CancellationToken cancellationToken = default)
		{
			if (check == null) throw new ArgumentNullException(nameof(check));
			if (check.Pay == null) throw new NullReferenceException(nameof(check.Pay));
			
			return _client.SendCheck(cancellationToken, new Models.SendCheck.RequestBody(CreateRequest(check.CheckId), check));
		}
		
		/// <summary>
		/// Проверяет состояние чека по id чека, полученному после вызова <see cref="SendCheck"/>
		/// </summary>
		/// <seealso cref="SendCheckAndWaitResult"/>
		public Task<Models.StateCheck.ResponseBody> StateCheck(string checkId, CancellationToken cancellationToken = default)
		{
			if (checkId == null) throw new ArgumentNullException(nameof(checkId));
			return _client.StateCheck(cancellationToken, new Models.StateCheck.RequestBody(CreateRequest(checkId), checkId));
		}

		/// <summary> Дефолтный таймаут отправки чека и ожидания результата </summary>
		public TimeSpan DefaultTimeout { get; set; } = TimeSpan.FromMinutes(5);
		private const long RESULT_OK = 0;

		/// <summary>
		/// Отправляет чек и дожидается его обработки
		/// Важно: Может выполняться продолжительное время
		/// </summary>
		/// <param name="check">Чек на отправку</param>
		/// <param name="cancellationToken">Токен, предоставляющий возможность отмены операции</param>
		/// <returns>
		/// Структуру <see cref="SendCheckResultOrException"/>, содержащую:
		/// ответ на команду отправки чека, ответ на команду о состоянии чека или исключение в случае ошибки
		/// </returns>
		public async Task<SendCheckResultOrException> SendCheckAndWaitResult(
			Check check, CancellationToken? cancellationToken = null)
		{
			if (check == null) throw new ArgumentNullException(nameof(check));
			if (check.CheckId == null) throw new ArgumentNullException(nameof(Check.CheckId));
			cancellationToken ??= new CancellationTokenSource(DefaultTimeout).Token;
			Models.SendCheck.ResponseBody? sendCheckResponse = null;
			Models.StateCheck.ResponseBody? stateCheckResponse = null;
			try
			{
				sendCheckResponse = await SendCheck(check, cancellationToken.Value);
				if (sendCheckResponse.ResultCode != RESULT_OK)
					return new SendCheckResultOrException(sendCheckResponse);

				do
				{
					cancellationToken.Value.ThrowIfCancellationRequested();
					await Task.Delay(2000, cancellationToken.Value);
					stateCheckResponse = await StateCheck(check.CheckId, cancellationToken.Value);
				} while (stateCheckResponse.CheckState?.State <= CheckStateEnum.FixationInKKT);
			}
			catch (Exception e)
			{
				return new SendCheckResultOrException(sendCheckResponse, stateCheckResponse, e);
			}
			
			return new SendCheckResultOrException(sendCheckResponse, stateCheckResponse);
		}

		/// <summary>
		/// Создает подписанный запрос по заданному <paramref name="checkId"/>
		/// </summary>
		internal Request CreateRequest(string checkId)
		{
			if (checkId == null) throw new ArgumentNullException(nameof(checkId));
			return new Request(_authorization.CompanyId, _authorization.Login, GetSign(checkId), _requireLink, _requireFiscalData);
		}

		/// <summary>
		/// Создает подпись из заданного <paramref name="checkId"/>
		/// </summary>
		internal string GetSign(string checkId)
		{
			if (checkId == null) throw new ArgumentNullException(nameof(checkId));
			return $"{_authorization.CompanyId}{_authorization.Password}{checkId}".Md5();
		}
		
		private static IKitOnlineClient Create()
		{
			var httpClient = new HttpClient()
			{
				BaseAddress = new Uri(HostUrl),
				Timeout = TimeSpan.FromSeconds(60)
			};
			
			return RestService.For<IKitOnlineClient>(httpClient, new RefitSettings()
			{
				ContentSerializer = new JsonContentSerializer(GetJsonSerializerSettings())
			}); 
		}
		
		internal static JsonSerializerSettings GetJsonSerializerSettings() => new JsonSerializerSettings()
		{
			NullValueHandling = NullValueHandling.Ignore
		};
	}
}