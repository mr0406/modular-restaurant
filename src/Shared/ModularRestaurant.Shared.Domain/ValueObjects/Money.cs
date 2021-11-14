using System;
using ModularRestaurant.Shared.Domain.Common;
using ModularRestaurant.Shared.Domain.Rules;

namespace ModularRestaurant.Shared.Domain.ValueObjects
{
    public class Money : ValueObject
    {
        public decimal Value { get; }
        public string Currency { get; }

        private Money()
        {
        }

        private Money(decimal value, string currency)
        {
            Value = value;
            Currency = currency;
        }

        public static Money Create(decimal value, string currency)
        {
            CheckRule(new MoneyCurrencyCannotBeNullOrEmptyRule(currency));
            return new Money(value, currency);
        }

        public static Money operator +(Money a, Money b)
        {
            CheckRule(new MoneyMustHaveTheSameCurrencyRule(a.Currency, b.Currency));
            return new Money(a.Value + b.Value, a.Currency); 
        }

        public static Money operator -(Money a, Money b)
        {
            CheckRule(new MoneyMustHaveTheSameCurrencyRule(a.Currency, b.Currency));
            return new Money(a.Value - b.Value, a.Currency);
        }

        public static Money operator *(Money a, decimal b)
        {
            return new Money(a.Value * b, a.Currency);
        }

        public static Money operator /(Money a, decimal b)
        {
            if (b == 0)
            {
                throw new DivideByZeroException();
            }

            return new Money(a.Value / b, a.Currency);
        }

        public static bool operator >(Money a, Money b)
        {
            CheckRule(new MoneyMustHaveTheSameCurrencyRule(a.Currency, b.Currency));
            return a.Value > b.Value;
        }

        public static bool operator <(Money a, Money b)
        {
            CheckRule(new MoneyMustHaveTheSameCurrencyRule(a.Currency, b.Currency));
            return a.Value < b.Value;
        }

        public static bool operator >=(Money a, Money b)
        {
            CheckRule(new MoneyMustHaveTheSameCurrencyRule(a.Currency, b.Currency));
            return a.Value >= b.Value;
        }

        public static bool operator <=(Money a, Money b)
        {
            CheckRule(new MoneyMustHaveTheSameCurrencyRule(a.Currency, b.Currency));
            return a.Value <= b.Value;
        }   
    }
}