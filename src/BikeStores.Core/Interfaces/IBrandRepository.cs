using BikeStores.Core.Entities;

namespace BikeStores.Core.Interfaces
{
    public interface IBrandRepository
    {
        IEnumerable<Brand> GetAllBrands();
        Brand GetBrandById(int id);
    }
}
