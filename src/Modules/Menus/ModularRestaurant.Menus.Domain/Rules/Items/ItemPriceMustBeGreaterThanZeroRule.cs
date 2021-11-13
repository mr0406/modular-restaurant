using ModularRestaurant.Shared.Domain.Common;
using ModularRestaurant.Shared.Domain.ValueObjects;

namespace ModularRestaurant.Menus.Domain.Rules.Items
{
    public class ItemPriceMustBeGreaterThanZeroRule : IBusinessRule
    {
        private readonly Money _price;

        internal ItemPriceMustBeGreaterThanZeroRule(Money price)
        {
            _price = price;
        }

        public bool IsBroken() => _price.Value <= 0;

        public string Message => "Item price must be greater than 0.";
    }
}