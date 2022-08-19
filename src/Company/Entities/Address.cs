namespace Company.Entities
{
    public enum AddressType
    {
        Unknown,
        Billing,
        Shipping,
    }

    public class Address
    {
        public string AddressLine { get; set; } = string.Empty;
        public string AddressLine2 { get; set; } = string.Empty;
        public AddressType Type { get; set; } = AddressType.Unknown;
        public string City { get; set; } = string.Empty;
        public string PostalCode { get; set; } = string.Empty;
        public string State { get; set; } = string.Empty;
        public string Country { get; set; } = string.Empty;

        public Address() { }
    }
}