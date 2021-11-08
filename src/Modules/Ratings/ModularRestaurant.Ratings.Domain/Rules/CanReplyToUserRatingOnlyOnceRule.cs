using ModularRestaurant.Shared.Domain.Common;

namespace ModularRestaurant.Ratings.Domain.Rules
{
    public class CanReplyToUserRatingOnlyOnceRule : IBusinessRule
    {
        private readonly string _existingReply;

        public CanReplyToUserRatingOnlyOnceRule(string existingReply)
        {
            _existingReply = existingReply;
        }

        public bool IsBroken() => _existingReply is not null;
        
        public string Message => "Cannot reply to user rating more than once.";
    }
}