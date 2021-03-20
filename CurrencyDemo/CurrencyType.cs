using System;
using System.Collections.Generic;
using System.Linq;

namespace CurrencyDemo
{
    public sealed class CurrencyType : ExtendedEnum<CurrencyTypeFilter>, ICurrencyType
    {
        private static readonly Lazy<CurrencyType>
            Lazy =
                new(() => new CurrencyType());

        public static CurrencyType Instance => Lazy.Value;

        private List<CurrencyType> CurrencyTypeList { get; }

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

        private CurrencyType(int id, string name, decimal value, CurrencyTypeFilter currencyTypeFilter) : base(id, name, value, currencyTypeFilter)
        {

        }

        public CurrencyType FromString(string currencyString)
        {
            return List().Single(r => string.Equals(r.Name, currencyString, StringComparison.OrdinalIgnoreCase));
        }

        public CurrencyType FromId(int id)
        {
            return List().Single(r => r.Id == id);
        }

        public IEnumerable<CurrencyType> List(CurrencyTypeFilter currencyTypeFilter = CurrencyTypeFilter.None)
        {
            return currencyTypeFilter == CurrencyTypeFilter.None ? CurrencyTypeList : CurrencyTypeList.Where(currencyType => currencyType.Filter == currencyTypeFilter);
        }

        public decimal GetDecimalValue(CurrencyType currencyType)
        {
            return Convert.ToDecimal(currencyType.Value);
        }

        public decimal GetCurrencyTypeFilterId(CurrencyType currencyType)
        {
            return (int)currencyType.Filter;
        }

        public override string ToString()
        {
            return Name;
        }
    }
}
