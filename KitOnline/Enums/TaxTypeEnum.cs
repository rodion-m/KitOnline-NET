using System.ComponentModel;
using KitOnline.Misc;

namespace KitOnline.Enums
{
public enum TaxTypeEnum
    {
        [AtolName(Name = "vat20")]
        [Description("НДС 20%")]
        Tax20 = 1,

        [AtolName(Name = "vat10")]
        [Description("НДС 10%")]
        Tax10 = 2,

        [AtolName(Name = "vat120")]
        [Description("НДС 20/120")]
        Tax20_120 = 3,

        [AtolName(Name = "vat110")]
        [Description("НДС 10/110")]
        Tax10_110 = 4,

        [AtolName(Name = "vat0")]
        [Description("НДС 0%")]
        Tax0 = 5,

        [AtolName(Name = "none")]
        [Description("Без НДС")]
        NoTax = 6
    }
}