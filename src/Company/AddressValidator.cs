namespace Company
{
    public class AddressValidator
    {
        public static List<string> Validate(Address address)
        {
            var errors = new List<string>();

            if (string.IsNullOrEmpty(address.Address1))
            {
                errors.Add("Address1 required");
            }

            if (address.Address1.Length > 100)
            {
                errors.Add("Address1 too long");
            }

            if (address.Address2.Length > 100)
            {
                errors.Add("Address2 too long");
            }

            if (string.IsNullOrEmpty(address.City))
            {
                errors.Add("City required");
            }

            if (address.City.Length > 50)
            {
                errors.Add("City too long");
            }

            if (string.IsNullOrEmpty(address.PostalCode))
            {
                errors.Add("Postal Code required");
            }

            if (address.PostalCode.Length > 6)
            {
                errors.Add("Postal Code too long");
            }

            if (string.IsNullOrEmpty(address.State))
            {
                errors.Add("State required");
            }

            if (address.State.Length > 20)
            {
                errors.Add("State too long");
            }

            if (string.IsNullOrEmpty(address.Country))
            {
                errors.Add("Country required");
            }

            if (!new string[] { "United States", "Canada" }.Contains(address.Country))
            {
                errors.Add("Wrong country");
            }

            return errors;
        }
    }
}