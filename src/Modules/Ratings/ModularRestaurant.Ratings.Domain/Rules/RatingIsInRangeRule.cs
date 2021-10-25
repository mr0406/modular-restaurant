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
        private const int MinValue = 1;
        private const int MaxValue = 5;

        public string Message => $"Rating must have value between {MinValue} and {MaxValue}.";

        private readonly int _value;

        public RatingIsInRangeRule(int value)
        {
            _value = value;
        }

        public bool IsBroken() => _value < MinValue || _value > MaxValue;
    }
}
