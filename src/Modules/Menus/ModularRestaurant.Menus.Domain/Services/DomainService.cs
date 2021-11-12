using ModularRestaurant.Shared.Domain.Common;
using ModularRestaurant.Shared.Domain.Exceptions;

namespace ModularRestaurant.Menus.Domain.Services
{
    public abstract class DomainService
    {
        protected void CheckRule(IBusinessRule rule)
        {
            if (rule.IsBroken()) throw new BusinessRuleException(rule);
        }
    }
}