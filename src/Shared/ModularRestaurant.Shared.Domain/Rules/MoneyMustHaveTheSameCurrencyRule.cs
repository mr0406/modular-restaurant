using System;
using ModularRestaurant.Shared.Domain.Common;

namespace ModularRestaurant.Shared.Domain.Rules
{
    public class MoneyMustHaveTheSameCurrencyRule : IBusinessRule
    {
        private readonly string _currencyA;
        private readonly string _currencyB;

        public MoneyMustHaveTheSameCurrencyRule(string currencyA, string currencyB)
        {
            _currencyA = currencyA;
            _currencyB = currencyB;
        }

        public bool IsBroken() => _currencyA != _currencyB;

        public string Message => "Currency must be the same.";
    }
}