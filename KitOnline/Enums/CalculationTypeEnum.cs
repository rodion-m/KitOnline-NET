using System.ComponentModel;
using KitOnline.Misc;

namespace KitOnline.Enums
{
	/// <summary>
	/// Признак расчета(применяется к чеку, а не товарной позиции)
	/// </summary>
	public enum CalculationTypeEnum
	{
		[AtolName(Name = "sell")]
		[Description("Приход")]
		Incoming = 1,

		[AtolName(Name = "sell_refund")]
		[Description("Возврат прихода")]
		ReturnIncoming = 2,

		[AtolName(Name = "buy")]
		[Description("Расход")]
		Consumption = 3,

		[AtolName(Name = "buy_refund")]
		[Description("Возврат расхода")]
		ReturnConsumption = 4
	}
}