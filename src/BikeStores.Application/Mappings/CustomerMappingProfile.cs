using BikeStores.Core.Entities;
using AutoMapper;
using BikeStores.Application.UseCases.GetCustomer;
using BikeStores.Application.UseCases.GetCustomerOrdersByEmail;

namespace BikeStores.Application.Mappings
{
    public class CustomerMappingProfile : Profile
    {
        public CustomerMappingProfile() {
            CreateMap<Customer, GetCustomerResponse>();

            // Map from Order entity to GetCustomerOrdersByEmailResponse
            CreateMap<Order, GetCustomerOrdersByEmailResponse>()
                .ForMember(dest => dest.OrderId, opt => opt.MapFrom(src => src.OrderId))
                .ForMember(dest => dest.OrderStatus, opt => opt.MapFrom(src => src.OrderStatus))
                .ForMember(dest => dest.OrderDate, opt => opt.MapFrom(src => src.OrderDate))
                .ForMember(dest => dest.RequiredDate, opt => opt.MapFrom(src => src.RequiredDate))
                .ForMember(dest => dest.ShippedDate, opt => opt.MapFrom(src => src.ShippedDate))
                .ForMember(dest => dest.StoreName, opt => opt.MapFrom(src => src.StoreName))
                .ForMember(dest => dest.StaffFirstName, opt => opt.MapFrom(src => src.StaffFirstName))
                .ForMember(dest => dest.StaffLastName, opt => opt.MapFrom(src => src.StaffLastName))
                .ForMember(dest => dest.TotalOrderValue, opt => opt.MapFrom(src => src.TotalOrderValue));
        }
    }
}
