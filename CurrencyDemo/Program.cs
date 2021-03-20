using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Net;

namespace CurrencyDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            var currencyType = CurrencyType.Instance;
            Console.WriteLine("Please enter your product currency. 1 for USD, 2 for Pounds and 3 for Euro.");
            var productCurrency = CurrencyTypeFilter.None;
            while (productCurrency == CurrencyTypeFilter.None)
            {
                var intValue = Console.ReadLine();
                var isNumber = int.TryParse(intValue, out var n);
                if (isNumber && n > 0 && n < 4)
                {
                    if (n == 1)
                    {
                        productCurrency = CurrencyTypeFilter.USD;
                        break;
                    }
                    else if (n == 2)
                    {
                        productCurrency = CurrencyTypeFilter.GBP;
                        break;
                    }
                    else if (n == 3)
                    {
                        productCurrency = CurrencyTypeFilter.EUR;
                        break;
                    }
                }
            }

            var _random = new Random();
            var productPrice = Math.Round(new decimal(_random.Next(999, 9999) + _random.NextDouble()), 2, MidpointRounding.ToEven);
            Console.WriteLine("A random price of " + productPrice + " " + GetDescription(productCurrency) + " is now due.");
            Console.WriteLine("Please enter your payment currency. 1 for USD, 2 for Pounds and 3 for Euro.");
            var paymentCurrency = CurrencyTypeFilter.None;
            while (paymentCurrency == CurrencyTypeFilter.None)
            {
                var intValue = Console.ReadLine();
                var isNumber = int.TryParse(intValue, out var n);
                if (isNumber && n > 0 && n < 4)
                {
                    if (n == 1)
                    {
                        paymentCurrency = CurrencyTypeFilter.USD;
                        break;
                    }
                    else if (n == 2)
                    {
                        paymentCurrency = CurrencyTypeFilter.GBP;
                        break;
                    }
                    else if (n == 3)
                    {
                        paymentCurrency = CurrencyTypeFilter.EUR;
                        break;
                    }
                }
            }

            decimal amountToBePaid = productPrice;
            if (productCurrency == paymentCurrency)
            {
                Console.WriteLine("As both currencies are in " + GetDescription(productCurrency) + ", no conversion is required");
            }
            else
            {
                amountToBePaid = CurrencyConversion(amountToBePaid, productCurrency.ToString(), paymentCurrency.ToString());
            }
            Console.WriteLine("Please enter a amount equal to or greater than " + amountToBePaid + " in " + GetDescription(paymentCurrency) + " to pay.");
            decimal paymentAmount = 0.0M;
            while (paymentAmount < amountToBePaid)
            {
                var decimalValue = Console.ReadLine();
                bool isDecimal = decimal.TryParse(decimalValue, out decimal n);
                if (isDecimal)
                {
                    if (n < amountToBePaid)
                    {
                        Console.WriteLine("Please enter a amount equal to or greater than " + amountToBePaid + " in " + GetDescription(paymentCurrency) + " to pay.");
                    }
                    else if (n >= amountToBePaid)
                    {
                        paymentAmount = n;
                        break;
                    }
                }
            }

            var payment = Payment.Builder.Amount(amountToBePaid).CurrencyType(paymentCurrency).AmountSubmitted(paymentAmount)
                .ChangeCurrencyType(productCurrency).Build();
            payment = ProcessPayment(payment, currencyType);
            var changeMessage = $"The customer must receive " + Math.Round(payment.Change, 2, MidpointRounding.ToEven) + " " + GetDescription(paymentCurrency) + " in change.";
            Console.WriteLine(changeMessage);
            Console.WriteLine("The change is made up as follows:");
            foreach (var denomination in payment.Denominations)
            {
                Console.WriteLine(denomination.Value + " " + denomination.Key.Name + " (s)");

            }
        }


        private static string GetDescription(CurrencyTypeFilter currencyType)
        {
            var type = currencyType.GetType();
            var name = Enum.GetName(type, currencyType);
            if (name != null)
            {
                var field = type.GetField(name);
                if (field != null)
                {
                    var attr =
                        Attribute.GetCustomAttribute(field,
                            typeof(DescriptionAttribute)) as DescriptionAttribute;
                    if (attr != null)
                    {
                        return attr.Description;
                    }
                }
            }
            return null;
        }

        public static decimal CurrencyConversion(decimal amount, string fromCurrency, string toCurrency)
        {
            var url = $"http://rate-exchange-1.appspot.com/currency?from={fromCurrency}&to={toCurrency}";

            using (var wc = new WebClient())
            {
                var json = wc.DownloadString(url);

                Newtonsoft.Json.Linq.JToken token = Newtonsoft.Json.Linq.JObject.Parse(json);
                var exchangeRate = (decimal)token.SelectToken("rate");

                return Math.Round((amount * exchangeRate), 2, MidpointRounding.ToEven);
            }
        }

        private static Payment ProcessPayment(Payment payment, CurrencyType currencyType)
        {
            var change = payment.AmountSubmitted - payment.Amount;
            payment.ChangeCurrencyType = payment.CurrencyType;
            payment.Change = change;
            payment.Denominations = new Dictionary<CurrencyType, int>();
            var currencyList = currencyType.List(payment.CurrencyType);
            foreach (var currency in currencyList)
            {
                var currencyValue = currency.GetDecimalValue(currency);
                var changeCount = (int)(change / currencyValue);
                if (changeCount <= 0) continue;
                payment.Denominations.Add(currency, changeCount);
                change %= currencyValue;
            }
            return payment;
        }
    }
}
