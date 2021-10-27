using ModularRestaurant.Shared.Domain.Common;

namespace ModularRestaurant.Ratings.Domain.Rules
{
    public class RestaurantReplyCannotExceedCharacterLimit : IBusinessRule
    {
        private const int MaxCharacters = 500;

        public string Message => $"Restaurant reply longer than max character limit: {MaxCharacters}.";

        private readonly string _text;

        public RestaurantReplyCannotExceedCharacterLimit(string text)
        {
            _text = text;
        }

        public bool IsBroken()
        {
            return _text.Length > MaxCharacters;
        }
    }
}