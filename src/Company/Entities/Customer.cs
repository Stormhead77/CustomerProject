namespace Company.Entities
{
    public class Customer : Person
    {
        public List<Address> Addresses { get; set; } = new List<Address>();
        public string PhoneNumber { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public List<string> Notes { get; set; } = new List<string>();
        public decimal? TotalPurchasesAmount { get; set; }

        public Customer() { }
    }
}