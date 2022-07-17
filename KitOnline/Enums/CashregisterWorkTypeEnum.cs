using System.ComponentModel;

namespace KitOnline.Enums
{
	/// <summary>
	///     Режим работы
	/// </summary>
	public enum CashregisterWorkTypeEnum
    {
        [Description("Шифрование")] Encryption = 0x01,

        [Description("Автономный")] Autonomous = 0x02,

        [Description("Автоматический")] Automatic = 0x04,

        [Description("Сфера услуг")] Services = 0x08,

        [Description("БСО")] Blanks = 0x10,

        [Description("Интернет-расчеты")] Internet = 0x20
    }
}