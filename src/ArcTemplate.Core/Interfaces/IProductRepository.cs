using ArcTemplate.Core.Entities;

namespace ArcTemplate.Core.Interfaces
{
    public interface IProductRepository
    {
        IEnumerable<Product> GetAllProducts();
        Product GetProductById(int id);
    }
}
