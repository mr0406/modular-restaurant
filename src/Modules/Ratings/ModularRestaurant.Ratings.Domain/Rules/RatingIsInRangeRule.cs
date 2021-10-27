using ModularRestaurant.Shared.Domain.Common;

namespace ModularRestaurant.Ratings.Domain.Rules
{
    public class RatingIsInRangeRule : IBusinessRule
    {
        private const int MinValue = 1;
        private const int MaxValue = 5;

        public string Message => $"Rating must have value between {MinValue} and {MaxValue}.";

        private readonly int _value;

        public RatingIsInRangeRule(int value)
        {
            _value = value;
        }

        public bool IsBroken()
        {
            return _value < MinValue || _value > MaxValue;
        }
    }
}