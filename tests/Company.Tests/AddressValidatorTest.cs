namespace Company.Tests
{
    public class AddressValidatorTest
    {
        [Fact]
        public void ShouldAddress1Correct()
        {
            var address = new Address("address1", "address2", AddressType.Billing, "city", "postalCode", "state", "country");
            var actual = AddressValidator.Validate(address);

            Assert.DoesNotContain("Address1 required", actual);
            Assert.DoesNotContain("Address1 too long", actual);
        }

        [Fact]
        public void ShouldAddress1Required()
        {
            var address = new Address(string.Empty, "address2", AddressType.Billing, "city", "postalCode", "state", "country");
            var actual = AddressValidator.Validate(address);

            Assert.Contains("Address1 required", actual);
        }

        [Fact]
        public void ShouldAddress1TooLong()
        {
            var address = new Address(new string('1', 101), "address2", AddressType.Billing, "city", "postalCode", "state", "country");
            var actual = AddressValidator.Validate(address);

            Assert.Contains("Address1 too long", actual);
        }

        [Fact]
        public void ShouldAddress2Correct()
        {
            var address = new Address("address1", "address2", AddressType.Billing, "city", "postalCode", "state", "country");
            var actual = AddressValidator.Validate(address);

            Assert.DoesNotContain("Address2 too long", actual);
        }

        [Fact]
        public void ShouldAddress2TooLong()
        {
            var address = new Address("address1", new string('1', 101), AddressType.Billing, "city", "postalCode", "state", "country");
            var actual = AddressValidator.Validate(address);

            Assert.Contains("Address2 too long", actual);
        }

        [Fact]
        public void ShouldCityCorrect()
        {
            var address = new Address("address1", "address2", AddressType.Billing, "city", "postalCode", "state", "country");
            var actual = AddressValidator.Validate(address);

            Assert.DoesNotContain("City required", actual);
            Assert.DoesNotContain("City too long", actual);
        }

        [Fact]
        public void ShouldCityRequired()
        {
            var address = new Address("address1", "address2", AddressType.Billing, string.Empty, "postalCode", "state", "country");
            var actual = AddressValidator.Validate(address);

            Assert.Contains("City required", actual);
        }

        [Fact]
        public void ShouldCityTooLong()
        {
            var address = new Address("address1", "address2", AddressType.Billing, new string('1', 51), "postalCode", "state", "country");
            var actual = AddressValidator.Validate(address);

            Assert.Contains("City too long", actual);
        }

        [Fact]
        public void ShouldPostalCodeCorrect()
        {
            var address = new Address("address1", "address2", AddressType.Billing, "city", "pCode", "state", "country");
            var actual = AddressValidator.Validate(address);

            Assert.DoesNotContain("Postal Code required", actual);
            Assert.DoesNotContain("Postal Code too long", actual);
        }

        [Fact]
        public void ShouldPostalCodeRequired()
        {
            var address = new Address("address1", "address2", AddressType.Billing, "city", string.Empty, "state", "country");
            var actual = AddressValidator.Validate(address);

            Assert.Contains("Postal Code required", actual);
        }

        [Fact]
        public void ShouldPostalCodeTooLong()
        {
            var address = new Address("address1", "address2", AddressType.Billing, "city", new string('1', 7), "state", "country");
            var actual = AddressValidator.Validate(address);

            Assert.Contains("Postal Code too long", actual);
        }

        [Fact]
        public void ShouldStateCorrect()
        {
            var address = new Address("address1", "address2", AddressType.Billing, "city", "postalCode", "state", "country");
            var actual = AddressValidator.Validate(address);

            Assert.DoesNotContain("State required", actual);
            Assert.DoesNotContain("State too long", actual);
        }

        [Fact]
        public void ShouldStateRequired()
        {
            var address = new Address("address1", "address2", AddressType.Billing, "city", "postalCode", string.Empty, "country");
            var actual = AddressValidator.Validate(address);

            Assert.Contains("State required", actual);
        }

        [Fact]
        public void ShouldStateTooLong()
        {
            var address = new Address("address1", "address2", AddressType.Billing, "city", "postalCode", new string('1', 21), "country");
            var actual = AddressValidator.Validate(address);

            Assert.Contains("State too long", actual);
        }

        [Theory]
        [InlineData("Canada")]
        [InlineData("United States")]
        public void ShouldCountryCorrect(string country)
        {
            var address = new Address("address1", "address2", AddressType.Billing, "city", "postalCode", "state", country);
            var actual = AddressValidator.Validate(address);

            Assert.DoesNotContain("Country required", actual);
            Assert.DoesNotContain("Wrong country", actual);
        }

        [Fact]
        public void ShouldCountryRequired()
        {
            var address = new Address("address1", "address2", AddressType.Billing, "city", "postalCode", "state", string.Empty);
            var actual = AddressValidator.Validate(address);

            Assert.Contains("Country required", actual);
        }

        [Fact]
        public void ShouldCountryWrong()
        {
            var address = new Address("address1", "address2", AddressType.Billing, "city", "postalCode", "state", "country");
            var actual = AddressValidator.Validate(address);

            Assert.Contains("Wrong country", actual);
        }
    }
}