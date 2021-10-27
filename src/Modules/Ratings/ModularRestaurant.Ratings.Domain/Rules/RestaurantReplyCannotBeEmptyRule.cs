using ModularRestaurant.Shared.Domain.Common;

namespace ModularRestaurant.Ratings.Domain.Rules
{
    public class RestaurantReplyCannotBeEmptyRule : IBusinessRule
    {
        public string Message => "Restaurant reply cannot be empty.";

        private readonly string _text;

        public RestaurantReplyCannotBeEmptyRule(string text)
        {
            _text = text;
        }

        public bool IsBroken()
        {
            return string.IsNullOrEmpty(_text);
        }
    }
}