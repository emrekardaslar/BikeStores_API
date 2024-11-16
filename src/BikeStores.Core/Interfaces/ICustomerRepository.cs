using BikeStores.Core.Entities;

namespace BikeStores.Core.Interfaces
{
    public interface ICustomerRepository
    {
        Task<IEnumerable<Order>> GetCustomerOrdersByEmailAsync(string email);
        Task<Customer> GetCustomerById(int id);
    }
}
