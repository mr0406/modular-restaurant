using System;
using MediatR;

namespace ModularRestaurant.Shared.Domain.Common
{
    public abstract class DomainEvent : INotification
    {
        public DateTime Timestamp { get; set; }
    }
}