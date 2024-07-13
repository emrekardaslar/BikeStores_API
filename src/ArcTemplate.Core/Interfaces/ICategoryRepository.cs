using ArcTemplate.Core.Entities;

namespace ArcTemplate.Core.Interfaces
{
    public interface ICategoryRepository
    {
        IEnumerable<Product> GetCategoryProducts(string name);
    }
}
