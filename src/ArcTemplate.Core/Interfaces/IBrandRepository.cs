using ArcTemplate.Core.Entities;

namespace ArcTemplate.Core.Interfaces
{
    public interface IBrandRepository
    {
        IEnumerable<Brand> GetAllBrands();
        Brand GetBrandById(int id);
    }
}
