namespace KitOnline.Enums
{
    public enum CheckStateEnum
    {
        /// <summary> Получен </summary>
        Received = 0,

        /// <summary> "Смаршрутизирован" </summary>
        Routed = 10,

        /// <summary> Обрабатывается </summary>
        Processing = 20,

        /// <summary> Фиксация в ККТ </summary>
        FixationInKKT = 30,

        /// <summary> Успешно </summary>
        Succeeded = 1000,

        /// <summary> Ошибочный </summary>
        Failed = 1010
    }
}