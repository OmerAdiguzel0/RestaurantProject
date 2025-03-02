using AutoMapper;
using Restaurant.DTOLayer.SocialMediaDTO;
using Restaurant.EntityLayer.Entities;

namespace WebAPI.Mapping
{
    public class SocialMediaMapping:Profile
    {
        public SocialMediaMapping()
        {
            CreateMap<SocialMedia, ResultSocialMediaDTO>().ReverseMap();
            CreateMap<SocialMedia, UpdateSocialMediaDTO>().ReverseMap();
            CreateMap<SocialMedia, GetSocialMediaDTO>().ReverseMap();
            CreateMap<SocialMedia, CreateSocialMediaDTO>().ReverseMap();

        }
    }
}
