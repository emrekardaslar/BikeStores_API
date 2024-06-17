using Xunit;
using ArcTemplate.Core.Entities;

namespace ArcTemplate.Core.Tests
{
    public class CustomerTests
    {
        [Fact]
        public void Customer_CanBeInitialized()
        {
            var customer = new Customer { Id = 1, Name = "Test Customer" };
            Assert.Equal(1, customer.Id);
            Assert.Equal("Test Customer", customer.Name);
        }
    }
}
