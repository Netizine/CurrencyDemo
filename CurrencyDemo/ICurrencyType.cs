using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CurrencyDemo
{
    /// <summary>
    /// ICurrencyType Interface
    /// </summary>
    public interface ICurrencyType
    {
        /// <summary>
        /// Gets the CurrencyType from the name string.
        /// </summary>
        /// <param name="currencyString">The currency string.</param>
        /// <returns>CurrencyType.</returns>
        CurrencyType FromString(string currencyString);
        /// <summary>
        /// Gets the CurrencyType from the identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>CurrencyType.</returns>
        CurrencyType FromId(int id);
        /// <summary>
        /// Returns a List of Currencies filtered by the specified filter.
        /// </summary>
        /// <param name="filter">The filter.</param>
        /// <returns>IEnumerable&lt;CurrencyType&gt;.</returns>
        IEnumerable<CurrencyType> List(CurrencyTypeFilter filter = CurrencyTypeFilter.None);
        /// <summary>
        /// Gets the decimal value.
        /// </summary>
        /// <param name="currencyType">Type of the currency.</param>
        /// <returns>System.Decimal.</returns>
        decimal GetDecimalValue(CurrencyType currencyType);
        /// <summary>
        /// Gets the currency type filter identifier.
        /// </summary>
        /// <param name="currencyType">Type of the currency.</param>
        /// <returns>System.Decimal.</returns>
        decimal GetCurrencyTypeFilterId(CurrencyType currencyType);
        /// <summary>
        /// Returns a <see cref="System.String" /> that represents this instance.
        /// </summary>
        /// <returns>A <see cref="System.String" /> that represents this instance.</returns>
        string ToString();
    }
}
