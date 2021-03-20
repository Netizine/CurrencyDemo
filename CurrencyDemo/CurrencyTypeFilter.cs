using System.ComponentModel;

namespace CurrencyDemo
{
    /// <summary>
    /// CurrencyTypeFilter Enum
    /// </summary>
    public enum CurrencyTypeFilter
    {
        [Description("None")]
        None = 0,
        [Description("United States Dollar")]
        USD = 1,
        [Description("Pound Sterling")]
        GBP = 2,
        [Description("Euro")]
        EUR = 3

    }
}
