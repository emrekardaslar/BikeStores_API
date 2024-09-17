using ArcTemplate.Application.UseCases.GetProduct;
using ArcTemplate.Core.Entities;
using AutoMapper;

public class ProductMappingProfile : Profile
{
    public ProductMappingProfile()
    {
        // Map from Product entity to GetProductResponse
        CreateMap<Product, GetProductResponse>();
    }
}
