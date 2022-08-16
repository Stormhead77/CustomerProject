namespace Company
{
    public enum AddressType
    {
        Shipping,
        Billing,
    }

    public class Address
    {
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public AddressType Type { get; set; }
        public string City { get; set; }
        public string PostalCode { get; set; }
        public string State { get; set; }
        public string Country { get; set; }

        public Address(string address1, string address2, AddressType type, string city, string postalCode, string state, string country)
        {
            Address1 = address1;
            Address2 = address2;
            Type = type;
            City = city;
            PostalCode = postalCode;
            State = state;
            Country = country;  
        }
    }
}