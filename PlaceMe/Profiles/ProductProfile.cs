using AutoMapper;
using PlaceMe.Infrastructure.Entities;
using PlaceMe.Models;

namespace PlaceMe.Profiles
{
    public class ProductProfile : Profile
    {
        public ProductProfile()
        {
            CreateMap<Product, ProductDto>().ReverseMap();
            CreateMap<ImageLine, ImageLineDto>().ReverseMap();
            CreateMap<DescriptionLine, DescriptionLineDto>().ReverseMap();
        }
    }
}
