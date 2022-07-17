namespace KitOnline.Models
{
#pragma warning disable 8618
    public class FiscalData
    {
        /// <summary> Дата и время в формате ДД.ММ.ГГ ЧЧ:мм </summary>
        public string Date { get; set; }

        /// <summary> Регистрационный номер кассы </summary>
        /// <remarks>Название в чеке: "РН ККТ" </remarks>
        public string Rnm { get; set; }

        /// <summary>Номер фискального накопителя. Криптографическое средство в составе ФР. </summary>
        /// <remarks>Название в чеке: "ФН"</remarks>
        public long StorageNumber { get; set; }

        /// <summary> Номер смены </summary>
        /// <remarks>Название в чеке: "Смена"</remarks>
        public int Session { get; set; }

        /// <summary> Номер чека </summary>
        /// <remarks>Название в чеке: "Чек"</remarks>
        public int CheckNumber { get; set; }

        /// <summary> Номер фискального документа </summary>
        /// <remarks>Название в чеке: "ФД" </remarks>
        public long Document { get; set; }

        /// <summary> Фискальный признак документа (Контрольное значение ФД) </summary>
        /// <remarks>Название в чеке: "ФП"</remarks>
        public long Sign { get; set; }


        /// <summary> Номер фабрики </summary>
        public long FactoryNumber { get; set; }
    }
}