using ModularRestaurant.Shared.Domain.Common;

namespace ModularRestaurant.Menus.Domain.Rules.Items
{
    public class ItemDescriptionCannotExceedCharacterLimitRule : IBusinessRule
    {
        private const int MaxCharacters = 500;
        
        private readonly string _itemDescription;

        internal ItemDescriptionCannotExceedCharacterLimitRule(string itemDescription)
        {
            _itemDescription = itemDescription;
        }
        
        public bool IsBroken() => _itemDescription.Length > MaxCharacters;
        
        public string Message => $"Description cannot be longer than: {MaxCharacters} characters.";
    }
}