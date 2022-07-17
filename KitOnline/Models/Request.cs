namespace KitOnline.Models
{
    public class Request
    {
        public Request(int companyId, string userLogin, string sign,
            bool requireLink = false,
            bool requireFiscalData = false)
        {
            CompanyId = companyId;
            UserLogin = userLogin;
            Sign = sign;
            Link = requireLink ? "1" : null;
            FiscalData = requireFiscalData ? "1" : null;
        }

        /// <summary>
        ///     Идентификатор компании из личного кабинета
        /// </summary>
        public int CompanyId { get; set; }

        /// <summary>
        ///     Логин пользователя с правами «API» от имени которого выполняется запрос
        /// </summary>
        public string UserLogin { get; set; }

        /// <summary>
        ///     Подпись объекта запроса
        /// </summary>
        /// <remarks>
        ///     Алгоритм формирования следующий: MD5(CompanyId+Password+CheckId(CheckNumber)), где:
        ///     MD5 – функция получения MD5-хэша строки.
        ///     «+» - конкатенация строк.
        ///     Password – пароль пользователя с правами «API» от имени которого выполняется запрос.
        /// </remarks>
        public string Sign { get; set; }

        /// <summary>
        ///     Запросить фискальные данные ("1")
        /// </summary>
        public string? FiscalData { get; set; }

        /// <summary>
        ///     Запросить ссылку на чек ("1")
        /// </summary>
        public string? Link { get; set; }
    }
}