using ArcTemplate.Core.Entities;
using ArcTemplate.Core.Interfaces;

namespace ArcTemplate.Infrastructure.Data
{
    public class ProductRepository : IProductRepository
    {
        public Product GetProductById(int id)
        {
            // Mock data
            return new Product { Id = id, Name = "Example Product", Price = 9.99M };
        }
    }
}
