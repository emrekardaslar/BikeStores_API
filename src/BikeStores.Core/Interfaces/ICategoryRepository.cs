using BikeStores.Core.Entities;

namespace BikeStores.Core.Interfaces
{
    public interface ICategoryRepository
    {
        IEnumerable<Product> GetCategoryProducts(string name);
    }
}
