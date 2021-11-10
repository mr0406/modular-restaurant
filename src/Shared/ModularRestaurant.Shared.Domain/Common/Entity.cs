using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using ModularRestaurant.Shared.Domain.Exceptions;

namespace ModularRestaurant.Shared.Domain.Common
{
    public abstract class Entity<T> : Entity where T : TypeId
    {
        public T Id { get; protected set; }
    }
    
    public abstract class Entity
    {
        [NotMapped]
        public IReadOnlyList<DomainEvent> Events => _events;
        protected List<DomainEvent> _events = new(); 
        
        protected static void CheckRule(IBusinessRule rule)
        {
            if (rule.IsBroken()) throw new BusinessRuleException(rule);
        }
    }
}