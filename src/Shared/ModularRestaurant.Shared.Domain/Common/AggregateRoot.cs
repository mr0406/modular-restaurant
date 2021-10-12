using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModularRestaurant.Shared.Domain.Common
{
    public class AggregateRoot<T>
    {
        public T Id { get; protected set; }

        protected static void CheckRule(IBusinessRule rule)
        {
            if (rule.IsBroken())
            {
                throw new BusinessRuleException(rule);
            }
        }
    }
}
