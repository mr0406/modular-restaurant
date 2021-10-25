using ModularRestaurant.Ratings.Domain.Rules;
using ModularRestaurant.Shared.Domain.Common;

namespace ModularRestaurant.Ratings.Domain.Entities
{
    public class Rating : ValueObject
    {
        public int Value { get; private set; }

        private Rating()
        {
        }
        private Rating(int value)
        {
            Value = value;
        }

        internal static Rating FromValue(int value)
        {
            CheckRule(new RatingIsInRangeRule(value));

            return new Rating(value);
        }
    }
}
