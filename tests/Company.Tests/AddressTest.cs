namespace Company.Tests
{
    public class AddressTest
    {
        [Fact]
        public void ShouldHaveAddressLine()
        {
            var address = new Address("address1", "address2", AddressType.Billing, "city", "postalCode", "state", "country");

            address.Address1.Equals("address1");
        }

        [Fact]
        public void ShouldHaveAddressLine2()
        {
            var address = new Address("address1", "address2", AddressType.Billing, "city", "postalCode", "state", "country");

            address.Address2.Equals("address2");
        }

        [Fact]
        public void ShouldHaveAddressType()
        {
            var address = new Address("address1", "address2", AddressType.Billing, "city", "postalCode", "state", "country");

            address.Type.Equals(AddressType.Billing);
        }

        [Fact]
        public void ShouldHaveCity()
        {
            var address = new Address("address1", "address2", AddressType.Billing, "city", "postalCode", "state", "country");

            address.City.Equals("city");
        }

        [Fact]
        public void ShouldHavePostalCode()
        {
            var address = new Address("address1", "address2", AddressType.Billing, "city", "postalCode", "state", "country");

            address.PostalCode.Equals("postalCode");
        }

        [Fact]
        public void ShouldHaveState()
        {
            var address = new Address("address1", "address2", AddressType.Billing, "city", "postalCode", "state", "country");

            address.State.Equals("state");
        }

        [Fact]
        public void ShouldHaveCountry()
        {
            var address = new Address("address1", "address2", AddressType.Billing, "city", "postalCode", "state", "country");

            address.Country.Equals("country");
        }
    }
}