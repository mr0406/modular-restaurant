using ModularRestaurant.Shared.Domain.Common;

namespace ModularRestaurant.Ratings.Domain.Rules
{
    public class CommentCannotExceedCharacterLimit : IBusinessRule
    {
        private const int MaxCharacters = 500;

        private readonly string _text;

        public CommentCannotExceedCharacterLimit(string text)
        {
            _text = text;
        }

        public bool IsBroken() => _text is not null && _text.Length > MaxCharacters;
        
        public string Message => $"Comment cannot be longer than: {MaxCharacters} characters.";
    }
}