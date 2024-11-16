using BikeStores.Core.Entities;
using AutoMapper;
using BikeStores.Application.UseCases.GetBrand;


namespace BikeStores.Application.Mappings
{
    public class BrandMappingProfile : Profile
    {
        public BrandMappingProfile() { 
            CreateMap<Brand, GetBrandResponse>();
        }
    }
}
