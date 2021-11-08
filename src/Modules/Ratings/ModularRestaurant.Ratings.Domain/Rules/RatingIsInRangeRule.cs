using ModularRestaurant.Shared.Domain.Common;

namespace ModularRestaurant.Ratings.Domain.Rules
{
    public class RatingIsInRangeRule : IBusinessRule
    {
        private const int MinValue = 1;
        private const int MaxValue = 5;

        private readonly int _value;

        public RatingIsInRangeRule(int value)
        {
            _value = value;
        }

        public bool IsBroken() => _value < MinValue || _value > MaxValue;
        
        public string Message => $"Rating must have value between {MinValue} and {MaxValue}.";
    }
}