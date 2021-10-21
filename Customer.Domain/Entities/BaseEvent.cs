using System;

namespace Customer.Domain.Entities
{
    public abstract class BaseEvent
    {
        public string AggregateId { get; set; }
        public int AggregateVersion { get; set; }
        public DateTime Created { get; set; }
        public abstract string Name { get; }
    }
}