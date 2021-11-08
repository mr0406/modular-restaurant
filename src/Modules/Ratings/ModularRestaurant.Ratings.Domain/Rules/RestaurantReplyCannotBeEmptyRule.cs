using ModularRestaurant.Shared.Domain.Common;

namespace ModularRestaurant.Ratings.Domain.Rules
{
    public class RestaurantReplyCannotBeEmptyRule : IBusinessRule
    {
        private readonly string _text;

        public RestaurantReplyCannotBeEmptyRule(string text)
        {
            _text = text;
        }

        public bool IsBroken() => string.IsNullOrEmpty(_text);
        
        public string Message => "Restaurant reply cannot be empty.";
    }
}