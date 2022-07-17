using System.ComponentModel;

namespace KitOnline.Enums
{
	/// <summary>
	///     Тип агента
	/// </summary>
	public enum AgentTypeEnum
    {
        [Description("БПА")] BankPaymentAgent = 1,

        [Description("БПСА")] BankPaymentSubagent = 2,

        [Description("ПА")] PaymentAgent = 4,

        [Description("ПСА")] PaymentSubagent = 8,

        [Description("Поверенный")] Attorney = 16,

        [Description("Комиссионер")] CommissionAgent = 32,

        [Description("Агент")] Agent = 64
    }
}