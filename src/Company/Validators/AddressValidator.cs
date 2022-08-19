using Company.Entities;
using FluentValidation;

namespace Company
{
    public class AddressValidator : AbstractValidator<Address>
    {
        public const string EmptyAddressLine = "Address Line required";
        public const string LongAddressLine = "Address Line too long";
        public const string LongAddressLine2 = "Address Line 2 too long";
        public const string WrongType = "Address Type required";
        public const string EmptyCity = "City required";
        public const string LongCity = "City too long";
        public const string EmptyPostalCode = "Postal Code required";
        public const string LongPostalCode = "Postal Code too long";
        public const string EmptyState = "State required";
        public const string LongState = "State too long";
        public const string EmptyCountry = "Country required";
        public const string WrongCountry = "Country wrong or unavailable";

        private const int AddressLineMaxLength = 100;
        private const int AddressLine2MaxLength = 100;
        private const int CityMaxLength = 50;
        private const int PostalCodeMaxLength = 6;
        private const int StateMaxLength = 20;
        private static readonly string[] AvailableCountries =
        {
            "Canada",
            "United States",
        };

        public AddressValidator()
        {
            RuleFor(address => address.AddressLine)
                .NotEmpty().WithMessage(EmptyAddressLine)
                .MaximumLength(AddressLineMaxLength).WithMessage(LongAddressLine);
            RuleFor(address => address.AddressLine2)
                .MaximumLength(AddressLine2MaxLength).WithMessage(LongAddressLine2);
            RuleFor(address => address.Type)
                .IsInEnum().Must(type => type != AddressType.Unknown).WithMessage(WrongType);
            RuleFor(address => address.City)
                .NotEmpty().WithMessage(EmptyCity)
                .MaximumLength(CityMaxLength).WithMessage(LongCity);
            RuleFor(address => address.PostalCode)
                .NotEmpty().WithMessage(EmptyPostalCode)
                .MaximumLength(PostalCodeMaxLength).WithMessage(LongPostalCode);
            RuleFor(address => address.State)
                .NotEmpty().WithMessage(EmptyState)
                .MaximumLength(StateMaxLength).WithMessage(LongState);
            RuleFor(address => address.Country)
                .NotEmpty().WithMessage(EmptyCountry)
                .Must(country => AvailableCountries.Contains(country, StringComparer.OrdinalIgnoreCase)).WithMessage(WrongCountry);
        }
    }
}