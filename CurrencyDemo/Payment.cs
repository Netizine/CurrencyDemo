using System.Collections.Generic;

namespace CurrencyDemo
{
    public class Payment
    {
        public decimal Amount { get; private set; }
        public decimal AmountSubmitted { get; private set; }
        public CurrencyTypeFilter CurrencyType { get; private set; }
        public decimal Change { get; set; }
        public CurrencyTypeFilter ChangeCurrencyType { get; set; }
        public Dictionary<CurrencyType, int> Denominations { get; set; }
        private Payment() { }
        public static PaymentBuilder Builder => new PaymentBuilder();
        public class PaymentBuilder
        {
            private decimal _amount;
            public PaymentBuilder Amount(decimal amount)
            {
                _amount = amount;
                return this;
            }
            private decimal _amountSubmitted;
            public PaymentBuilder AmountSubmitted(decimal amountSubmitted)
            {
                _amountSubmitted = amountSubmitted;
                return this;
            }
            private CurrencyTypeFilter _currencyType;
            public PaymentBuilder CurrencyType(CurrencyTypeFilter currencyType)
            {
                _currencyType = currencyType;
                return this;
            }
            private decimal _change;
            public PaymentBuilder Change(decimal change)
            {
                _change = change;
                return this;
            }
            private CurrencyTypeFilter _changeCurrencyType;
            public PaymentBuilder ChangeCurrencyType(CurrencyTypeFilter changeCurrencyType)
            {
                _changeCurrencyType = changeCurrencyType;
                return this;
            }
            private Dictionary<CurrencyType, int> _denominations;
            public PaymentBuilder Denominations(Dictionary<CurrencyType, int> denominations)
            {
                _denominations = denominations;
                return this;
            }

            public Payment Build()
            {
                Validate();
                return new Payment
                {
                    Amount = _amount,
                    AmountSubmitted = _amountSubmitted,
                    CurrencyType = _currencyType,
                    Change = _change,
                    ChangeCurrencyType = _changeCurrencyType,
                    Denominations = _denominations,
                };
            }
            public void Validate()
            {
                void AddError(Dictionary<string, string> items, string property, string message)
                {
                    if (items.TryGetValue(property, out var error))
                        items[property] = $"{error}\n{message}";
                    else
                        items[property] = message;
                }
                var errors = new Dictionary<string, string>();
                if (_amount == default) AddError(errors, "Amount", "Value is required");
                if (_amountSubmitted == default) AddError(errors, "AmountSubmitted", "Value is required");
                if (_currencyType == default) AddError(errors, "CurrencyType", "Value is required");

                if (_amountSubmitted < _amount)
                {
                    AddError(errors, "AmountSubmitted", "AmountSubmitted must be equal to or more than amount required");
                }

                if (errors.Count > 0)
                    throw new BuilderException(errors);
            }
        }
    }
}
