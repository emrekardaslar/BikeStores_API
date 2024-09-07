using ArcTemplate.Core.Entities;

namespace ArcTemplate.Core.Interfaces
{
    public interface ICustomerRepository
    {
        Task<IEnumerable<Order>> GetCustomerOrdersByEmailAsync(string email);
        Customer GetCustomerById(int id);
    }
}
