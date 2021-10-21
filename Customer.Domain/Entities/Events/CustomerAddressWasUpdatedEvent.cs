using Customer.Domain.Entities.ValueObjects;

namespace Customer.Domain.Entities.Events
{
    public class CustomerAddressWasUpdatedEvent : BaseEvent
    {
        public override string Name => EventName();
        public AddressVo Address { get; set; }
        public static string EventName() => "CUSTOMER_ADDRESS_WAS_UPDATED";
    }
}
