namespace KitOnline.Models.SendCheck
{
    public class ResponseBody
    {
        /// <summary> Результат выполнения запроса (0 - ОК, иначе - ошибка) </summary>
        public int ResultCode { get; set; }

        public long CheckQueueId { get; set; }

        public string? ErrorMessage { get; set; }

        /// <summary> Фискальные данные </summary>
        public FiscalData? FiscalData { get; set; }
    }
}