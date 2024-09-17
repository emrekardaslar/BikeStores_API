using ArcTemplate.Application.UseCases.GetCustomer;
using ArcTemplate.Core.Entities;
using AutoMapper;

namespace ArcTemplate.Application.Mappings
{
    public class CustomerMappingProfile : Profile
    {
        public CustomerMappingProfile() {
            CreateMap<Customer, GetCustomerResponse>();
        }
    }
}
