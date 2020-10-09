using AutoMapper;
using PlaceMe.Infrastructure.Entities;
using PlaceMe.Models;

namespace PlaceMe.Profiles
{
    public class PromotionProfile : Profile
    {
        public PromotionProfile()
        {
            CreateMap<Promotion, PromotionDto>().ReverseMap();
            CreateMap<PromotionLine, PromotionLineDto>().ReverseMap();
        }
    }
}
