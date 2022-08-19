using Company.Entities;
using FluentValidation.TestHelper;

namespace Company.Tests.Validators
{
    public class CustomerValidatorTest
    {
        [Fact]
        public void ShouldFirstNameCorrect()
        {
            var validator = new CustomerValidator();
            var customer = new Customer { FirstName = "Harold" };
            var result = validator.TestValidate(customer);

            result.ShouldNotHaveValidationErrorFor(x => x.FirstName);
        }

        [Fact]
        public void ShouldFirstNameTooLong()
        {
            var validator = new CustomerValidator();
            var customer = new Customer { FirstName = new string('a', 51) };
            var result = validator.TestValidate(customer);

            result.ShouldHaveValidationErrorFor(customer => customer.FirstName).WithErrorMessage(CustomerValidator.LongFirstName);
        }

        [Fact]
        public void ShouldLastNameCorrect()
        {
            var validator = new CustomerValidator();
            var customer = new Customer { LastName = "Johnson" };
            var result = validator.TestValidate(customer);

            result.ShouldNotHaveValidationErrorFor(x => x.LastName);
        }

        [Fact]
        public void ShouldLastNameRequired()
        {
            var validator = new CustomerValidator();
            var customer = new Customer { LastName = string.Empty };
            var result = validator.TestValidate(customer);

            result.ShouldHaveValidationErrorFor(x => x.LastName).WithErrorMessage(CustomerValidator.EmptyLastName);
        }

        [Fact]
        public void ShouldLastNameTooLong()
        {
            var validator = new CustomerValidator();
            var customer = new Customer { LastName = new string('a', 51) };
            var result = validator.TestValidate(customer);

            result.ShouldHaveValidationErrorFor(x => x.LastName).WithErrorMessage(CustomerValidator.LongLastName);
        }

        [Fact]
        public void ShouldAddressesCorrect()
        {
            var validator = new CustomerValidator();
            var customer = new Customer { Addresses = new List<Address> { new Address() } };
            var result = validator.TestValidate(customer);

            result.ShouldNotHaveValidationErrorFor(x => x.Addresses);
        }

        [Fact]
        public void ShouldAddressesRequired()
        {
            var validator = new CustomerValidator();
            var customer = new Customer { Addresses = new List<Address>() };
            var result = validator.TestValidate(customer);

            result.ShouldHaveValidationErrorFor(x => x.Addresses).WithErrorMessage(CustomerValidator.EmptyAddresses);
        }

        [Fact]
        public void ShouldPhoneNumberCorrect()
        {
            var validator = new CustomerValidator();
            var customer = new Customer { PhoneNumber = "+12673935933" };
            var result = validator.TestValidate(customer);

            result.ShouldNotHaveValidationErrorFor(x => x.PhoneNumber);
        }

        [Theory]
        [InlineData("")]
        [InlineData("+a2673935933")]
        [InlineData("+1a673935933")]
        public void ShouldPhoneNumberFormatRequired(string phoneNumber)
        {
            var validator = new CustomerValidator();
            var customer = new Customer { PhoneNumber = phoneNumber };
            var result = validator.TestValidate(customer);

            result.ShouldHaveValidationErrorFor(x => x.PhoneNumber).WithErrorMessage(CustomerValidator.WrongPhoneNumber);
        }

        [Fact]
        public void ShouldEmailCorrect()
        {
            var validator = new CustomerValidator();
            var customer = new Customer { Email = "HaroldSJohnson@armyspy.com" };
            var result = validator.TestValidate(customer);

            result.ShouldNotHaveValidationErrorFor(x => x.Email);
        }

        [Theory]
        [InlineData("e@mail")]
        [InlineData("email.com")]
        [InlineData("@email.com")]
        [InlineData("email@.com")]
        public void ShouldEmailFormatRequired(string email)
        {
            var validator = new CustomerValidator();
            var customer = new Customer { Email = email };
            var result = validator.TestValidate(customer);

            result.ShouldHaveValidationErrorFor(x => x.Email).WithErrorMessage(CustomerValidator.WrongEmail);
        }

        [Fact]
        public void ShouldNotesCorrect()
        {
            var validator = new CustomerValidator();
            var customer = new Customer { Notes = new List<string> { "Note" } };
            var result = validator.TestValidate(customer);

            result.ShouldNotHaveValidationErrorFor(x => x.Notes);
        }

        [Fact]
        public void ShouldNotesRequired()
        {
            var validator = new CustomerValidator();
            var customer = new Customer { Notes = new List<string>() };
            var result = validator.TestValidate(customer);

            result.ShouldHaveValidationErrorFor(x => x.Notes).WithErrorMessage(CustomerValidator.EmptyNotes);
        }
    }
}