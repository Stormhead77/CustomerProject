namespace Company
{
    public class Customer : Person
    {
        public List<Address> Addresses { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public List<string> Notes { get; set; }
        public decimal? TotalPurchasesAmount { get; set; }

        public Customer(string firstName, string lastName, List<Address> addresses, string phone, string email, List<string> notes, decimal? totalPurchasesAmount) : base(firstName, lastName)
        {
            Addresses = addresses;
            Phone = phone;
            Email = email;
            Notes = notes;
            TotalPurchasesAmount = totalPurchasesAmount;
        }
    }
}