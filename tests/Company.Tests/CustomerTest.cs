namespace Company.Tests
{
    public class CustomerTest
    {
        [Fact]
        public void ShouldHaveFirstName()
        {
            var address = new Customer("firstName", "lastName", new List<Address>(), "phone", "email", new List<string>(), 0);

            address.FirstName.Equals("firstName");
        }

        [Fact]
        public void ShouldHaveLastName()
        {
            var address = new Customer("firstName", "lastName", new List<Address>(), "phone", "email", new List<string>(), 0);

            address.LastName.Equals("lastName");
        }

        [Fact]
        public void ShouldHaveAddresses()
        {
            var address = new Customer("firstName", "lastName", new List<Address>(), "phone", "email", new List<string>(), 0);

            address.Addresses.Equals(new List<Address>());
        }

        [Fact]
        public void ShouldHavePhone()
        {
            var address = new Customer("firstName", "lastName", new List<Address>(), "phone", "email", new List<string>(), 0);

            address.Phone.Equals("phone");
        }

        [Fact]
        public void ShouldHaveEmail()
        {
            var address = new Customer("firstName", "lastName", new List<Address>(), "phone", "email", new List<string>(), 0);

            address.Email.Equals("email");
        }

        [Fact]
        public void ShouldHaveNotes()
        {
            var address = new Customer("firstName", "lastName", new List<Address>(), "phone", "email", new List<string>(), 0);

            address.Notes.Equals(new List<string>());
        }

        [Fact]
        public void ShouldHaveTotalPurchasesAmount()
        {
            var address = new Customer("firstName", "lastName", new List<Address>(), "phone", "email", new List<string>(), 0);

            address.TotalPurchasesAmount.Equals("totalPurchasesAmount");
        }
    }
}