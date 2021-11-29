using ModularRestaurant.Shared.Domain.Common;

namespace ModularRestaurant.Shared.Domain.Rules
{
    public class MoneyCurrencyCannotBeNullOrEmptyRule : IBusinessRule
    {
        private readonly string _currency;

        public MoneyCurrencyCannotBeNullOrEmptyRule(string currency)
        {
            _currency = currency;
        }

        public bool IsBroken() => string.IsNullOrEmpty(_currency);

        public string Message => "Currency cannot be null or empty.";
    }
}