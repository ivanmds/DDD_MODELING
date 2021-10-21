using System;

namespace Customer.Domain.Entities.Events
{
    public class CustomerWasCreatedEvent : BaseEvent
    {
        public override string Name => EventName();
        
        public string CustomerName { get; set; }
        public string MotherName { get; set; }
        public DateTime Birthdate { get; set; }

        public static string EventName() => "CUSTOMER_WAS_CREATED";
    }
}
