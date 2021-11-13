using ModularRestaurant.Shared.Domain.Exceptions;

namespace ModularRestaurant.Shared.Domain.Common
{
    public abstract class DomainService
    {
        protected void CheckRule(IBusinessRule rule)
        {
            if (rule.IsBroken()) throw new BusinessRuleException(rule);
        }
    }
}