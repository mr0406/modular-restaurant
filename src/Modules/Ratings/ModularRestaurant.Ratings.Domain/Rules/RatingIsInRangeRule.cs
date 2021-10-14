using ModularRestaurant.Shared.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModularRestaurant.Ratings.Domain.Rules
{
    internal class RatingIsInRangeRule : IBusinessRule
    {
        private const int MIN_VALUE = 1;
        private const int MAX_VALUE = 5;

        public string Message => $"Rating must have value between {MIN_VALUE} and {MAX_VALUE}.";

        private readonly int _value;

        public RatingIsInRangeRule(int value)
        {
            _value = value;
        }

        public bool IsBroken() => _value < MIN_VALUE || _value > MAX_VALUE;
    }
}
