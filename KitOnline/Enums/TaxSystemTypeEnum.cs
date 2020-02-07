using System.ComponentModel;
using KitOnline.Misc;

namespace KitOnline.Enums
{
	/// <summary>
	/// СНО
	/// </summary>
	public enum TaxSystemTypeEnum
	{
		[AtolName(Name="osn")]
		[Description("ОСН")]
		OSN = 1,

		[AtolName(Name = "usn_income")]
		[Description("УСН доход")]
		USN_Income = 2,

		[AtolName(Name = "usn_income_outcome")]
		[Description("УСН доход-расход")]
		USN_Income_Outcome = 4,

		[AtolName(Name = "envd")]
		[Description("ЕНВД")]
		ENVD = 8,

		[AtolName(Name = "esn")]
		[Description("ЕСН")]
		ESN = 16,

		[AtolName(Name = "patent")]
		[Description("ПСН")]
		Patent = 32
	}
}