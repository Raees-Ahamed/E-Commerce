using AutoMapper;
using PlaceMe.Infrastructure.Entities;
using PlaceMe.Models;

namespace PlaceMe.Profiles
{
    public class OrderProfile : Profile
    {
        public OrderProfile()
        {
            CreateMap<Order, OrderDto>().ReverseMap();
            CreateMap<OrderLine, OrderLineDto>().ReverseMap();
            CreateMap<User, UserDto>().ReverseMap();
        }
    }
}
