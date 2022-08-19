using Company.Entities;
using FluentValidation;

namespace Company
{
    public class CustomerValidator : AbstractValidator<Customer>
    {

        public const string LongFirstName = "First Name too long";
        public const string EmptyLastName = "Last Name required";
        public const string LongLastName = "Last Name too long";
        public const string EmptyAddresses = "At least one Address required";
        public const string WrongPhoneNumber = "Incorrect Phone Number format";
        public const string WrongEmail = "Incorrect Email format";
        public const string EmptyNotes = "At least one Note required";

        private const int FirstNameMaxLength = 50;
        private const int LastNameMaxLength = 50;
        private const string PhoneNumberRegex = @"^\+[1-9]\d{1,14}$";
        private const string EmailRegex = @"^\S+@\S+\.(\w{2,3})+$";

        public CustomerValidator()
        {
            RuleFor(customer => customer.FirstName)
                .MaximumLength(FirstNameMaxLength).WithMessage(LongFirstName);
            RuleFor(customer => customer.LastName)
                .NotEmpty().WithMessage(EmptyLastName)
                .MaximumLength(LastNameMaxLength).WithMessage(LongLastName);
            RuleFor(customer => customer.Addresses)
                .NotEmpty().WithMessage(EmptyAddresses);
            RuleFor(customer => customer.PhoneNumber)
                .Matches(PhoneNumberRegex).WithMessage(WrongPhoneNumber);
            RuleFor(customer => customer.Notes)
                .NotEmpty().WithMessage(EmptyNotes);
            RuleFor(customer => customer.Email)
                .Matches(EmailRegex).WithMessage(WrongEmail);
        }
    }
}