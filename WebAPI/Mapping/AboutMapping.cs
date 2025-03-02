using AutoMapper;
using Restaurant.DTOLayer.AboutDTO;
using Restaurant.EntityLayer.Entities;

namespace WebAPI.Mapping
{
    public class AboutMapping:Profile
    {
        public AboutMapping()
        {
            CreateMap<About, ResultAboutDTO>().ReverseMap();
            CreateMap<About, CreateAboutDTO>().ReverseMap();
            CreateMap<About, GetAboutDTO>().ReverseMap();
            CreateMap<About, UpdateAboutDTO>().ReverseMap();
        }
    }
}
