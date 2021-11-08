using ModularRestaurant.Shared.Domain.Exceptions;

namespace ModularRestaurant.Shared.Domain.Common
{
    public abstract class Entity<T>
    {
        public T Id { get; protected set; }
        
        protected static void CheckRule(IBusinessRule rule)
        {
            if (rule.IsBroken()) throw new BusinessRuleException(rule);
        }
    }
    
    public abstract class Entity
    {
        protected static void CheckRule(IBusinessRule rule)
        {
            if (rule.IsBroken()) throw new BusinessRuleException(rule);
        }
    }
}