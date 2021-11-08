using ModularRestaurant.Shared.Domain.Common;

namespace ModularRestaurant.Ratings.Domain.Rules
{
    public class RestaurantReplyCannotExceedCharacterLimit : IBusinessRule
    {
        private const int MaxCharacters = 500;

        private readonly string _text;

        public RestaurantReplyCannotExceedCharacterLimit(string text)
        {
            _text = text;
        }

        public bool IsBroken() => _text.Length > MaxCharacters;
        
        public string Message => $"Restaurant reply longer than max character limit: {MaxCharacters}.";
    }
}