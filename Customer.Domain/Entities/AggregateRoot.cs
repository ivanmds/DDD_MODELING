using System;
using System.Collections.Generic;

namespace Customer.Domain.Entities
{
    public abstract class AggregateRoot
    {
        private List<BaseEvent> _uncommittedEvents;

        public AggregateRoot()
        {
            _uncommittedEvents = new List<BaseEvent>();
            Created = DateTime.UtcNow;
        }

        public string Id { get; protected set; }
        public DateTime Created { get; protected set; }
        public int Version { get; protected set; }


        protected abstract void Apply(BaseEvent @event);
        protected void UpVersion() => Version++;

        public void ApplyEvent(BaseEvent @event)
        {
            Apply(@event);
            Version = @event.AggregateVersion;
        }

        protected void RaiseEvent(BaseEvent @event)
        {
            UpVersion();
            @event.AggregateVersion = Version;
            @event.AggregateId = Id;
            _uncommittedEvents.Add(@event);
            ApplyEvent(@event);
        }

        public IReadOnlyCollection<BaseEvent> GetUncommittedEvents => _uncommittedEvents;
        public void ClearUncommittedEvents() => _uncommittedEvents.Clear();
    }
}
