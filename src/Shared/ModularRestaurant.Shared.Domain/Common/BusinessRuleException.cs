using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModularRestaurant.Shared.Domain.Common
{
    public class BusinessRuleException : Exception
    {
        public IBusinessRule BrokenRule { get; }

        public string Details { get; }

        public BusinessRuleException(IBusinessRule brokenRule)
            :base(brokenRule.Message)
        {
            BrokenRule = brokenRule;
            Details = brokenRule.Message;
        }

        public override string ToString() => $"{BrokenRule.GetType().FullName}: {BrokenRule.Message}";
    }
}
