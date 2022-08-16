using System.Text.RegularExpressions;

namespace Company
{
    public class CustomerValidator
    {
        public static List<string> Validate(Customer customer)
        {
            var errors = new List<string>();

            if (customer.FirstName.Length > 50)
            {
                errors.Add("First Name too long");
            }

            if (string.IsNullOrEmpty(customer.LastName))
            {
                errors.Add("Last Name required");
            }

            if (customer.LastName.Length > 50)
            {
                errors.Add("Last Name too long");
            }

            if (customer.Addresses.Count < 1)
            {
                errors.Add("Addresses cannot be empty");
            }
            
            if (!Regex.IsMatch(customer.Phone, @"^\+[1-9]\d{1,14}$"))
            {
                errors.Add("Phone Number wrong format");
            }

            if (!Regex.IsMatch(customer.Email, @"^\S+@\S+$"))
            {
                errors.Add("Email wrong format");
            }

            if (customer.Notes.Count < 1)
            {
                errors.Add("Notes cannot be empty");
            }

            return errors;
        }
    }
}