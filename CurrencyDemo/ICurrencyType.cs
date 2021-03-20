using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CurrencyDemo
{
    public interface ICurrencyType
    {
        CurrencyType FromString(string currencyString);
        CurrencyType FromId(int id);
        IEnumerable<CurrencyType> List(CurrencyTypeFilter filter = CurrencyTypeFilter.None);
        decimal GetDecimalValue(CurrencyType currencyType);
        decimal GetCurrencyTypeFilterId(CurrencyType currencyType);
        string ToString();
    }
}
