using System;

namespace ModularRestaurant.Shared.Domain.Exceptions
{
    public class ObjectNotFoundException : Exception
    {
        public Type Type { get; }
        
        //TODO: consider user TypeId instead of Guid
        public Guid Id { get; }
        
        public ObjectNotFoundException(Type type, Guid Id)
            : base($"{type.Name} with Id: {Id} not found.")
        {
            Type = type;
        }
    }
}