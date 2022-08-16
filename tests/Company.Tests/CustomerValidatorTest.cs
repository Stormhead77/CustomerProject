namespace Company.Tests
{
    public class CustomerValidatorTest
    {
        [Fact]
        public void ShouldFirstNameCorrect()
        {
            var customer = new Customer("firstName", "lastName", new List<Address>(), "phone", "email", new List<string>(), 0);
            var actual = CustomerValidator.Validate(customer);

            Assert.DoesNotContain("First Name too long", actual);
        }

        [Fact]
        public void ShouldFirstNameTooLong()
        {
            var customer = new Customer(new string('1', 51), "lastName", new List<Address>(), "phone", "email", new List<string>(), 0);
            var actual = CustomerValidator.Validate(customer);

            Assert.Contains("First Name too long", actual);
        }

        [Fact]
        public void ShouldLastNameCorrect()
        {
            var customer = new Customer("firstName", "lastName", new List<Address>(), "phone", "email", new List<string>(), 0);
            var actual = CustomerValidator.Validate(customer);

            Assert.DoesNotContain("Last Name required", actual);
            Assert.DoesNotContain("Last Name too long", actual);
        }

        [Fact]
        public void ShouldLastNameRequired()
        {
            var customer = new Customer("firstName", string.Empty, new List<Address>(), "phone", "email", new List<string>(), 0);
            var actual = CustomerValidator.Validate(customer);

            Assert.Contains("Last Name required", actual);
        }

        [Fact]
        public void ShouldLastNameTooLong()
        {
            var customer = new Customer("firstName", new string('1', 51), new List<Address>(), "phone", "email", new List<string>(), 0);
            var actual = CustomerValidator.Validate(customer);

            Assert.Contains("Last Name too long", actual);
        }

        [Fact]
        public void ShouldAddressesCorrect()
        {
            var customer = new Customer("firstName", "lastName", new List<Address> { new Address("address1", "address2", AddressType.Billing, "city", "postalCode", "state", "country") }, "phone", "email", new List<string>(), 0);
            var actual = CustomerValidator.Validate(customer);

            Assert.DoesNotContain("Addresses cannot be empty", actual);
        }

        [Fact]
        public void ShouldAddressesRequired()
        {
            var customer = new Customer("firstName", "lastName", new List<Address>(), "phone", "email", new List<string>(), 0);
            var actual = CustomerValidator.Validate(customer);

            Assert.Contains("Addresses cannot be empty", actual);
        }

        [Fact]
        public void ShouldPhoneNumberCorrect()
        {
            var customer = new Customer("firstName", "lastName", new List<Address>(), "+111111111111111", "email", new List<string>(), 0);
            var actual = CustomerValidator.Validate(customer);

            Assert.DoesNotContain("Phone Number wrong format", actual);
        }

        [Fact]
        public void ShouldPhoneNumberFormatRequired()
        {
            var customer = new Customer("firstName", "lastName", new List<Address>(), "phone", "email", new List<string>(), 0);
            var actual = CustomerValidator.Validate(customer);

            Assert.Contains("Phone Number wrong format", actual);
        }

        [Fact]
        public void ShouldEmailCorrect()
        {
            var customer = new Customer("firstName", "lastName", new List<Address>(), "phone", "tempmail@mail.com", new List<string>(), 0);
            var actual = CustomerValidator.Validate(customer);

            Assert.DoesNotContain("Email wrong format", actual);
        }

        [Fact]
        public void ShouldEmailFormatRequired()
        {
            var customer = new Customer("firstName", "lastName", new List<Address>(), "phone", "email", new List<string>(), 0);
            var actual = CustomerValidator.Validate(customer);

            Assert.Contains("Email wrong format", actual);
        }

        [Fact]
        public void ShouldNotesCorrect()
        {
            var customer = new Customer("firstName", "lastName", new List<Address>(), "phone", "email", new List<string> { "Note" }, 0);
            var actual = CustomerValidator.Validate(customer);

            Assert.DoesNotContain("Notes cannot be empty", actual);
        }

        [Fact]
        public void ShouldNotesRequired()
        {
            var customer = new Customer("firstName", "lastName", new List<Address>(), "phone", "email", new List<string>(), 0);
            var actual = CustomerValidator.Validate(customer);

            Assert.Contains("Notes cannot be empty", actual);
        }
    }
}