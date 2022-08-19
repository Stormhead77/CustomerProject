using Company.Entities;

namespace Company.Tests.Entities
{
    public class CustomerTest
    {
        [Fact]
        public void ShouldBeAbleToCreateCustomer()
        {
            var customer = new Customer
            {
                FirstName = "Harold",
                LastName = "Johnson",
                Addresses = new List<Address>(),
                PhoneNumber = "+12673935933",
                Email = "HaroldSJohnson@armyspy.com",
                Notes = new List<string>(),
                TotalPurchasesAmount = 0
            };

            Assert.NotNull(customer);
            Assert.Equal("Harold", customer.FirstName);
            Assert.Equal("Johnson", customer.LastName);
            Assert.Equal(new List<Address>(), customer.Addresses);
            Assert.Equal("+12673935933", customer.PhoneNumber);
            Assert.Equal("HaroldSJohnson@armyspy.com", customer.Email);
            Assert.Equal(new List<string>(), customer.Notes);
            Assert.Equal(0m, customer.TotalPurchasesAmount);
        }

        [Fact]
        public void ShouldTotalPurchasesAmountCanBeNull()
        {
            var customer = new Customer { TotalPurchasesAmount = null };

            Assert.Null(customer.TotalPurchasesAmount);
        }
    }
}