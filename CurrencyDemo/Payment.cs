using System.Collections.Generic;

namespace CurrencyDemo
{
    /// <summary>
    /// Payment Class.
    /// </summary>
    public class Payment
    {
        /// <summary>
        /// Gets the amount.
        /// </summary>
        /// <value>The amount.</value>
        public decimal Amount { get; private set; }
        /// <summary>
        /// Gets the amount submitted.
        /// </summary>
        /// <value>The amount submitted.</value>
        public decimal AmountSubmitted { get; private set; }
        /// <summary>
        /// Gets the type of the currency.
        /// </summary>
        /// <value>The type of the currency.</value>
        public CurrencyTypeFilter CurrencyType { get; private set; }
        /// <summary>
        /// Gets or sets the change.
        /// </summary>
        /// <value>The change.</value>
        public decimal Change { get; set; }
        /// <summary>
        /// Gets or sets the type of the change currency.
        /// </summary>
        /// <value>The type of the change currency.</value>
        public CurrencyTypeFilter ChangeCurrencyType { get; set; }
        /// <summary>
        /// Gets or sets the denominations.
        /// </summary>
        /// <value>The denominations.</value>
        public Dictionary<CurrencyType, int> Denominations { get; set; }
        /// <summary>
        /// Prevents a default instance of the <see cref="Payment"/> class from being created.
        /// </summary>
        private Payment() { }
        /// <summary>
        /// Gets the builder.
        /// </summary>
        /// <value>The builder.</value>
        public static PaymentBuilder Builder => new PaymentBuilder();
        /// <summary>
        /// PaymentBuilder Class.
        /// </summary>
        public class PaymentBuilder
        {
            /// <summary>
            /// The amount
            /// </summary>
            private decimal _amount;
            /// <summary>
            /// The specified amount to pay.
            /// </summary>
            /// <param name="amount">The amount.</param>
            /// <returns>PaymentBuilder.</returns>
            public PaymentBuilder Amount(decimal amount)
            {
                _amount = amount;
                return this;
            }
            /// <summary>
            /// The amount submitted
            /// </summary>
            private decimal _amountSubmitted;
            /// <summary>
            /// The amount submitted for payment.
            /// </summary>
            /// <param name="amountSubmitted">The amount submitted.</param>
            /// <returns>PaymentBuilder.</returns>
            public PaymentBuilder AmountSubmitted(decimal amountSubmitted)
            {
                _amountSubmitted = amountSubmitted;
                return this;
            }
            /// <summary>
            /// The currency type
            /// </summary>
            private CurrencyTypeFilter _currencyType;
            /// <summary>
            /// The currency type.
            /// </summary>
            /// <param name="currencyType">Type of the currency.</param>
            /// <returns>PaymentBuilder.</returns>
            public PaymentBuilder CurrencyType(CurrencyTypeFilter currencyType)
            {
                _currencyType = currencyType;
                return this;
            }
            /// <summary>
            /// The change
            /// </summary>
            private decimal _change;
            /// <summary>
            /// The specified change to be returned.
            /// </summary>
            /// <param name="change">The change.</param>
            /// <returns>PaymentBuilder.</returns>
            public PaymentBuilder Change(decimal change)
            {
                _change = change;
                return this;
            }
            /// <summary>
            /// The change currency type
            /// </summary>
            private CurrencyTypeFilter _changeCurrencyType;
            /// <summary>
            /// The type of the change currency.
            /// </summary>
            /// <param name="changeCurrencyType">Type of the change currency.</param>
            /// <returns>PaymentBuilder.</returns>
            public PaymentBuilder ChangeCurrencyType(CurrencyTypeFilter changeCurrencyType)
            {
                _changeCurrencyType = changeCurrencyType;
                return this;
            }
            /// <summary>
            /// The change denominations
            /// </summary>
            private Dictionary<CurrencyType, int> _denominations;
            /// <summary>
            /// The denominations of change to return.
            /// </summary>
            /// <param name="denominations">The denominations.</param>
            /// <returns>PaymentBuilder.</returns>
            public PaymentBuilder Denominations(Dictionary<CurrencyType, int> denominations)
            {
                _denominations = denominations;
                return this;
            }

            /// <summary>
            /// Builds this instance.
            /// </summary>
            /// <returns>Payment.</returns>
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
            /// <summary>
            /// Validates this instance.
            /// </summary>
            /// <exception cref="CurrencyDemo.BuilderException"></exception>
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
