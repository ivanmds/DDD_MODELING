using Customer.Domain.Entities.Events;
using Customer.Domain.Entities.ValueObjects;
using System;

namespace Customer.Domain.Entities
{
    public class Customer : AggregateRoot
    {
        public Customer() { }

        public string Name { get; private set; }
        public string MotherName { get; private set; }
        public DateTime Birthdate { get; private set; }
        public AddressVo Address { get; private set; }

        protected override void Apply(BaseEvent @event)
        {
            if(@event.Name == CustomerWasCreatedEvent.EventName())
            {
                var eventParse = @event as CustomerWasCreatedEvent;
                Name = eventParse.CustomerName;
                MotherName = eventParse.MotherName;
                Birthdate = eventParse.Birthdate;
            }
            else if(@event.Name == CustomerAddressWasUpdatedEvent.EventName())
            {
                var eventParse = @event as CustomerAddressWasUpdatedEvent;
                Address = eventParse.Address;
            }
            else
            {
                throw new Exception("Event not supported");
            }
        }

        public static Customer Create(string name, string motherName, DateTime birthdate)
        {
            var @event = new CustomerWasCreatedEvent
            {
                AggregateId = Guid.NewGuid().ToString(),
                CustomerName = name,
                MotherName = motherName,
                Birthdate = birthdate
            };

            var customer = new Customer();
            customer.RaiseEvent(@event);

            return customer;
        }

        public void UpdateAddress(AddressVo address)
        {
            var @event = new CustomerAddressWasUpdatedEvent
            {
                Address = address
            };

            RaiseEvent(@event);
        }
    }
}
