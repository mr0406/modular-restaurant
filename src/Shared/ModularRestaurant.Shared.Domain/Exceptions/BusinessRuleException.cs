using System;
using ModularRestaurant.Shared.Domain.Common;

namespace ModularRestaurant.Shared.Domain.Exceptions
{
    public class BusinessRuleException : Exception
    {
        public IBusinessRule BrokenRule { get; }

        public string Details { get; }

        public BusinessRuleException(IBusinessRule brokenRule)
            : base(brokenRule.Message)
        {
            BrokenRule = brokenRule;
            Details = brokenRule.Message;
        }
    }
}