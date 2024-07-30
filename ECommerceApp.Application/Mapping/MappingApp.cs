
using ECommerceApp.Core.Models;
using ECommerceApp.Application.DTOs;
using AutoMapper;
namespace ECommerceApp.Application.Mapping
{
    public class MappingApp : Profile
    {
        public MappingApp()
        {
            CreateMap<UserRegisterDTO, ApplicationUser>()
                .ForMember(dest => dest.UserName, opt => opt.MapFrom(src => src.Email));
            CreateMap<ProductInsertDTO, Product>();
            CreateMap<CartItemDTO, CartItem>();
            CreateMap<ReviewInsertDTO, Review>();
            CreateMap<OrderDTO, Order>();
        }
    }
}