using System;

namespace ModularRestaurant.Shared.Domain.Common
{
    public class EntityNotFoundException : Exception
    {
        public string EntityName { get; }

        public Guid Id { get; }

        public EntityNotFoundException(string entityName, Guid id)
            : base($"{entityName} with Id: {id} not found.")
        {
            EntityName = entityName;
            Id = id;
        }
    }
}