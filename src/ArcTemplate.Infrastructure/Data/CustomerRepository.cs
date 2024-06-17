using ArcTemplate.Core.Entities;
using ArcTemplate.Core.Interfaces;

namespace ArcTemplate.Infrastructure.Data
{
    public class CustomerRepository : ICustomerRepository
    {
        public Customer GetCustomerById(int id)
        {
            // Mock data
            return new Customer { Id = id, Name = "Example Customer" };
        }
    }
}
