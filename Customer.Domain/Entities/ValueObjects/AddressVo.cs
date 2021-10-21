namespace Customer.Domain.Entities.ValueObjects
{
    public class AddressVo
    {
        public string Street { get; private set; }
        public string Number { get; private set; }
        public string State { get; private set; }
        public string City { get; private set; }
        public string Zipcode { get; private set; }
        public string Complement { get; private set; }
        public string Country { get; private set; }
    }
}
