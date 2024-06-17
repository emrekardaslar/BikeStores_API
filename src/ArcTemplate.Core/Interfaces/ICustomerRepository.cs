using ArcTemplate.Core.Entities;

namespace ArcTemplate.Core.Interfaces
{
    public interface ICustomerRepository
    {
        Customer GetCustomerById(int id);
    }
}
