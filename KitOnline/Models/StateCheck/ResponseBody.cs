namespace KitOnline.Models.StateCheck
{
    public class ResponseBody
    {
        /// <summary> Результат выполнения запроса (0 - ОК, иначе - ошибка) </summary>
        public int ResultCode { get; set; }

        public CheckState? CheckState { get; set; }

        public string? ErrorMessage { get; set; }

        /// <summary> Фискальные данные </summary>
        public FiscalData? FiscalData { get; set; }

        /// <summary> Ссылка на чек </summary>
        public string? Link { get; set; }
    }
}