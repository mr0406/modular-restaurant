using ModularRestaurant.Shared.Domain.Common;

namespace ModularRestaurant.Ratings.Domain.Rules
{
    public class CommentCannotBeEmptyRule : IBusinessRule
    {
        public string Message => "Comment cannot be empty.";

        private readonly string _text;

        public CommentCannotBeEmptyRule(string text)
        {
            _text = text;
        }

        public bool IsBroken()
        {
            return string.IsNullOrEmpty(_text);
        }
    }
}