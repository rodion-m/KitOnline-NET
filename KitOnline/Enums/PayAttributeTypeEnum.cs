using System.ComponentModel;

namespace KitOnline.Enums
{
	/// <summary>
	///     Признак способа расчета
	/// </summary>
	public enum PayAttributeTypeEnum
    {
        [AtolName(Name = "full_prepayment")] [Description("Предоплата 100%")]
        FullPrepayment = 1,

        [AtolName(Name = "prepayment")] [Description("Предоплата")]
        Prepayment = 2,

        [AtolName(Name = "advance")] [Description("Аванс")]
        Advance = 3,

        [AtolName(Name = "full_payment")] [Description("Полный расчет")]
        FullPayment = 4,

        [AtolName(Name = "partial_payment")] [Description("Частичный расчет и кредит")]
        PartialPayment = 5,


        [AtolName(Name = "credit")] [Description("Передача в кредит")]
        Credit = 6,


        [AtolName(Name = "credit_payment")] [Description("Оплата кредита")]
        CreditPayment = 7
    }
}