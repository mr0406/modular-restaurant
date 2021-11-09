using System;

namespace ModularRestaurant.Shared.Domain.Exceptions
{
    public class ObjectNotFoundException : NotFoundException
    {
        public readonly Type Type;
        //TODO: consider user TypeId instead of Guid
        public readonly Guid Id;
        
        public ObjectNotFoundException(Type type, Guid id)
            : base($"{type.Name} with Id: {id} not found.")
        {
            Type = type;
            Id = id;
        }
    }
}