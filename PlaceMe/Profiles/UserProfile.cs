using AutoMapper;
using PlaceMe.Infrastructure.Entities;
using PlaceMe.Models;

namespace PlaceMe.Profiles
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<User, UserDto>().ReverseMap();
            CreateMap<AddressLine, AddressLineDto>().ReverseMap();
        }
    }
}
