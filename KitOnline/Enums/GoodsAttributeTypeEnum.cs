using System.ComponentModel;
using KitOnline.Misc;

namespace KitOnline.Enums
{
	/// <summary>
	/// Признак предмета расчета
	/// </summary>
	public enum GoodsAttributeTypeEnum
	{
		[AtolName(Name="commodity")]
		[Description("Товар")]
		Commodity = 1,

		[AtolName(Name = "excise")]
		[Description("Подакцизный товар")]
		Excise = 2,

		[AtolName(Name = "job")]
		[Description("Работа")]
		Job = 3,

		[AtolName(Name = "service")]
		[Description("Услуга")]
		Service = 4,

		[AtolName(Name = "gambling_bet")]
		[Description("Ставка азартной игры")]
		Type5 = 5,

		[AtolName(Name = "gambling_prize")]
		[Description("Выигрыш азартной игры")]
		Type6 = 6,

		[AtolName(Name = "lottery")]
		[Description("Лотерейный билет")]
		Type7 = 7,

		[AtolName(Name = "lottery_prize")]
		[Description("Выигрыш лотереи")]
		Type8 = 8,

		[AtolName(Name = "intellectual_activity")]
		[Description("Интеллектуальная деятельность")]
		Type9 = 9,

		[AtolName(Name = "payment")]
		[Description("Аванс, задаток")]
		Type10 = 10,

		[AtolName(Name = "agent_commission")]
		[Description("Вознаграждение агента")]
		Type11 = 11,

		[AtolName(Name = "composite")]
		[Description("Составной предмет расчета")]
		Type12 = 12,

		[AtolName(Name = "another")]
		[Description("Иной предмет расчета")]
		Type13 = 13,

		[AtolName(Name = "property_right")]
		[Description("Имущественное право")]
		Type14 = 14,

		[AtolName(Name = "non-operating_gain")]
		[Description("Внереализационный доход")]
		Type15 = 15,

		[AtolName(Name = "insurance_premium")]
		[Description("Страховые взносы")]
		Type16 = 16,

		[AtolName(Name = "sales_tax")]
		[Description("Торговый сбор")]
		Type17 = 17,

		[AtolName(Name = "resort_fee")]
		[Description("Курортный сбор")]
		Type18 = 18,

		[Description("Залог")]
		Type19 = 19
	}
}