using System;
using System.Collections.Generic;
using System.Linq;

namespace CurrencyDemo
{
    /// <summary>
    /// CurrencyType Class. This class cannot be inherited.
    /// Implements the <see cref="CurrencyDemo.ExtendedEnum`1" />
    /// Implements the <see cref="CurrencyDemo.ICurrencyType" />
    /// </summary>
    /// <seealso cref="CurrencyDemo.ExtendedEnum`1" />
    /// <seealso cref="CurrencyDemo.ICurrencyType" />
    public sealed class CurrencyType : ExtendedEnum<CurrencyTypeFilter>, ICurrencyType
    {
        /// <summary>
        /// Provides support for lazy initialization
        /// </summary>
        private static readonly Lazy<CurrencyType>
            Lazy =
                new(() => new CurrencyType());

        /// <summary>
        /// Gets the instance.
        /// </summary>
        /// <value>The instance.</value>
        public static CurrencyType Instance => Lazy.Value;

        /// <summary>
        /// Sets the currency type list.
        /// </summary>
        /// <value>The currency type list.</value>
        private List<CurrencyType> CurrencyTypeList { get; }

        /// <summary>
        /// Prevents a default instance of the <see cref="CurrencyType"/> class from being created.
        /// </summary>
        private CurrencyType()
        {
            CurrencyTypeList = new List<CurrencyType>
            {
                //United States Dollar
                new(101, "$100", 100.00M, CurrencyTypeFilter.USD),
                new(102, "$50", 50.00M, CurrencyTypeFilter.USD),
                new(103, "$20", 20.00M, CurrencyTypeFilter.USD),
                new(104, "$10", 10.00M, CurrencyTypeFilter.USD),
                new(105, "$5", 5.00M, CurrencyTypeFilter.USD),
                new(106, "$2", 2.00M, CurrencyTypeFilter.USD),
                new(107, "$1", 1.00M, CurrencyTypeFilter.USD),
                new(108, "50¢", 0.50M, CurrencyTypeFilter.USD),
                new(109, "25¢", 0.25M, CurrencyTypeFilter.USD),
                new(110, "10¢", 0.10M, CurrencyTypeFilter.USD),
                new(111, "5¢", 0.05M, CurrencyTypeFilter.USD),
                new(112, "1¢", 0.01M, CurrencyTypeFilter.USD),
                //Pound Sterling 
                new(201, "£50", 50.00M, CurrencyTypeFilter.GBP),
                new(202, "£20", 20.00M, CurrencyTypeFilter.GBP),
                new(203, "£10", 10.00M, CurrencyTypeFilter.GBP),
                new(204, "£5", 5.00M, CurrencyTypeFilter.GBP),
                new(205, "£2", 2.00M, CurrencyTypeFilter.GBP),
                new(206, "£1", 1.00M, CurrencyTypeFilter.GBP),
                new(207, "50p", 0.50M, CurrencyTypeFilter.GBP),
                new(208, "20p", 0.20M, CurrencyTypeFilter.GBP),
                new(209, "10p", 0.10M, CurrencyTypeFilter.GBP),
                new(210, "5p", 0.05M, CurrencyTypeFilter.GBP),
                new(211, "2p", 0.02M, CurrencyTypeFilter.GBP),
                new(212, "1p", 0.01M, CurrencyTypeFilter.GBP),
                //Euro
                new(301, "€500", 500.00M, CurrencyTypeFilter.EUR),
                new(302, "€200", 200.00M, CurrencyTypeFilter.EUR),
                new(303, "€100", 100.00M, CurrencyTypeFilter.EUR),
                new(304, "€50", 50.00M, CurrencyTypeFilter.EUR),
                new(305, "€20", 20.00M, CurrencyTypeFilter.EUR),
                new(306, "€10", 10.00M, CurrencyTypeFilter.EUR),
                new(307, "€5", 5.00M, CurrencyTypeFilter.EUR),
                new(308, "€2", 2.00M, CurrencyTypeFilter.EUR),
                new(309, "€1", 1.00M, CurrencyTypeFilter.EUR),
                new(310, "50¢", 0.50M, CurrencyTypeFilter.EUR),
                new(311, "20¢", 0.20M, CurrencyTypeFilter.EUR),
                new(312, "10¢", 0.10M, CurrencyTypeFilter.EUR),
                new(313, "5¢", 0.05M, CurrencyTypeFilter.EUR),
                new(314, "2¢", 0.02M, CurrencyTypeFilter.EUR),
                new(315, "1¢", 0.01M, CurrencyTypeFilter.EUR)
            };

        }

        /// <summary>
        /// Initializes a new instance of the <see cref="CurrencyType"/> class.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="name">The name.</param>
        /// <param name="value">The value.</param>
        /// <param name="currencyTypeFilter">The currency type filter.</param>
        private CurrencyType(int id, string name, decimal value, CurrencyTypeFilter currencyTypeFilter) : base(id, name, value, currencyTypeFilter)
        {

        }

        /// <summary>
        /// Gets the CurrencyType from the name string.
        /// </summary>
        /// <param name="currencyString">The currency string.</param>
        /// <returns>CurrencyType.</returns>
        public CurrencyType FromString(string currencyString)
        {
            return List().Single(r => string.Equals(r.Name, currencyString, StringComparison.OrdinalIgnoreCase));
        }

        /// <summary>
        /// Gets the CurrencyType from the identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>CurrencyType.</returns>
        public CurrencyType FromId(int id)
        {
            return List().Single(r => r.Id == id);
        }

        /// <summary>
        /// Lists the specified currency type filter.
        /// </summary>
        /// <param name="currencyTypeFilter">The currency type filter.</param>
        /// <returns>System.Collections.Generic.IEnumerable&lt;CurrencyDemo.CurrencyType&gt;.</returns>
        public IEnumerable<CurrencyType> List(CurrencyTypeFilter currencyTypeFilter = CurrencyTypeFilter.None)
        {
            return currencyTypeFilter == CurrencyTypeFilter.None ? CurrencyTypeList : CurrencyTypeList.Where(currencyType => currencyType.Filter == currencyTypeFilter);
        }

        /// <summary>
        /// Gets the decimal value.
        /// </summary>
        /// <param name="currencyType">Type of the currency.</param>
        /// <returns>System.Decimal.</returns>
        public decimal GetDecimalValue(CurrencyType currencyType)
        {
            return Convert.ToDecimal(currencyType.Value);
        }

        /// <summary>
        /// Gets the currency type filter identifier.
        /// </summary>
        /// <param name="currencyType">Type of the currency.</param>
        /// <returns>System.Decimal.</returns>
        public decimal GetCurrencyTypeFilterId(CurrencyType currencyType)
        {
            return (int)currencyType.Filter;
        }

        /// <summary>
        /// Converts to string.
        /// </summary>
        /// <returns>string.</returns>
        public override string ToString()
        {
            return Name;
        }
    }
}
