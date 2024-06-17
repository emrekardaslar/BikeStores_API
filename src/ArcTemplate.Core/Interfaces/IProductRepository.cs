using ArcTemplate.Core.Entities;

namespace ArcTemplate.Core.Interfaces
{
    public interface IProductRepository
    {
        Product GetProductById(int id);
    }
}
