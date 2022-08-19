using Company.Entities;
using FluentValidation.TestHelper;

namespace Company.Tests.Validators
{
    public class AddressValidatorTest
    {
        [Fact]
        public void ShouldAddressLineCorrect()
        {
            var validator = new AddressValidator();
            var address = new Address { AddressLine = "4100 Holly Street" };
            var result = validator.TestValidate(address);

            result.ShouldNotHaveValidationErrorFor(address => address.AddressLine);
        }

        [Theory]
        [InlineData("")]
        [InlineData(null)]
        public void ShouldAddressLineRequired(string addressLine)
        {
            var validator = new AddressValidator();
            var address = new Address { AddressLine = addressLine };
            var result = validator.TestValidate(address);

            result.ShouldHaveValidationErrorFor(address => address.AddressLine).WithErrorMessage(AddressValidator.EmptyAddressLine);
        }

        [Fact]
        public void ShouldAddressLineTooLong()
        {
            var validator = new AddressValidator();
            var address = new Address { AddressLine = new string('a', 101) };
            var result = validator.TestValidate(address);

            result.ShouldHaveValidationErrorFor(address => address.AddressLine).WithErrorMessage(AddressValidator.LongAddressLine);
        }

        [Theory]
        [InlineData("")]
        [InlineData("4101 Holly Street")]
        [InlineData(null)]
        public void ShouldAddressLine2Correct(string addressLine2)
        {
            var validator = new AddressValidator();
            var address = new Address { AddressLine2 = addressLine2 };
            var result = validator.TestValidate(address);

            result.ShouldNotHaveValidationErrorFor(address => address.AddressLine2);
        }

        [Fact]
        public void ShouldAddressLine2TooLong()
        {
            var validator = new AddressValidator();
            var address = new Address { AddressLine2 = new string('a', 101) };
            var result = validator.TestValidate(address);

            result.ShouldHaveValidationErrorFor(address => address.AddressLine2).WithErrorMessage(AddressValidator.LongAddressLine2);
        }

        [Fact]
        public void ShouldCityCorrect()
        {
            var validator = new AddressValidator();
            var address = new Address { City = "Blue Ridge" };
            var result = validator.TestValidate(address);

            result.ShouldNotHaveValidationErrorFor(address => address.City);
        }

        [Theory]
        [InlineData("")]
        [InlineData(null)]
        public void ShouldCityRequired(string city)
        {
            var validator = new AddressValidator();
            var address = new Address { City = city };
            var result = validator.TestValidate(address);

            result.ShouldHaveValidationErrorFor(address => address.City).WithErrorMessage(AddressValidator.EmptyCity);
        }

        [Fact]
        public void ShouldCityTooLong()
        {
            var validator = new AddressValidator();
            var address = new Address { City = new string('a', 51) };
            var result = validator.TestValidate(address);

            result.ShouldHaveValidationErrorFor(address => address.City).WithErrorMessage(AddressValidator.LongCity);
        }

        [Fact]
        public void ShouldPostalCodeCorrect()
        {
            var validator = new AddressValidator();
            var address = new Address { PostalCode = "30513" };
            var result = validator.TestValidate(address);

            result.ShouldNotHaveValidationErrorFor(address => address.PostalCode);
        }

        [Theory]
        [InlineData("")]
        [InlineData(null)]
        public void ShouldPostalCodeRequired(string postalCode)
        {
            var validator = new AddressValidator();
            var address = new Address { PostalCode = postalCode };
            var result = validator.TestValidate(address);

            result.ShouldHaveValidationErrorFor(address => address.PostalCode).WithErrorMessage(AddressValidator.EmptyPostalCode);
        }

        [Fact]
        public void ShouldPostalCodeTooLong()
        {
            var validator = new AddressValidator();
            var address = new Address { PostalCode = new string('1', 7) };
            var result = validator.TestValidate(address);

            result.ShouldHaveValidationErrorFor(address => address.PostalCode).WithErrorMessage(AddressValidator.LongPostalCode);
        }

        [Fact]
        public void ShouldStateCorrect()
        {
            var validator = new AddressValidator();
            var address = new Address { State = "GA" };
            var result = validator.TestValidate(address);

            result.ShouldNotHaveValidationErrorFor(address => address.State);
        }

        [Theory]
        [InlineData("")]
        [InlineData(null)]
        public void ShouldStateRequired(string state)
        {
            var validator = new AddressValidator();
            var address = new Address { State = state };
            var result = validator.TestValidate(address);

            result.ShouldHaveValidationErrorFor(address => address.State).WithErrorMessage(AddressValidator.EmptyState);
        }

        [Fact]
        public void ShouldStateTooLong()
        {
            var validator = new AddressValidator();
            var address = new Address { State = new string('a', 21) };
            var result = validator.TestValidate(address);

            result.ShouldHaveValidationErrorFor(address => address.State).WithErrorMessage(AddressValidator.LongState);
        }

        [Theory]
        [InlineData("canada")]
        [InlineData("Canada")]
        [InlineData("CANADA")]
        [InlineData("united states")]
        [InlineData("United States")]
        [InlineData("UNITED STATES")]
        public void ShouldCountryCorrect(string country)
        {
            var validator = new AddressValidator();
            var address = new Address { Country = country };
            var result = validator.TestValidate(address);

            result.ShouldNotHaveValidationErrorFor(address => address.Country);
        }

        [Theory]
        [InlineData("")]
        [InlineData(null)]
        public void ShouldCountryRequired(string country)
        {
            var validator = new AddressValidator();
            var address = new Address { Country = country };
            var result = validator.TestValidate(address);

            result.ShouldHaveValidationErrorFor(address => address.Country).WithErrorMessage(AddressValidator.EmptyCountry);
        }

        [Fact]
        public void ShouldCountryWrong()
        {
            var validator = new AddressValidator();
            var address = new Address { Country = "China" };
            var result = validator.TestValidate(address);

            result.ShouldHaveValidationErrorFor(address => address.Country).WithErrorMessage(AddressValidator.WrongCountry);
        }
    }
}