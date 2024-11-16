using BikeStores.Application.UseCases.GetProduct;
using BikeStores.Core.Entities;
using AutoMapper;

public class ProductMappingProfile : Profile
{
    public ProductMappingProfile()
    {
        // Map from Product entity to GetProductResponse
        CreateMap<Product, GetProductResponse>();
    }
}
