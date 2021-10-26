using ModularRestaurant.Ratings.Domain.Rules;
using ModularRestaurant.Shared.Domain.Common;

namespace ModularRestaurant.Ratings.Domain.Entities
{
    public class Comment : Entity
    {
        public string Text { get; private set; }

        private Comment()
        {
        }

        private Comment(string text)
        {
            Text = text;
        }

        internal static Comment FromText(string text)
        {
            CheckRule(new CommentCannotBeEmptyRule(text));
            CheckRule(new CommentCannotExceedCharacterLimit(text));

            return new Comment(text);
        }
    }
}