using ArcTemplate.Application.UseCases.GetBrand;
using ArcTemplate.Core.Entities;
using AutoMapper;


namespace ArcTemplate.Application.Mappings
{
    public class BrandMappingProfile : Profile
    {
        public BrandMappingProfile() { 
            CreateMap<Brand, GetBrandResponse>();
        }
    }
}
