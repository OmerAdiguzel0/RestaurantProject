using AutoMapper;
using Restaurant.DTOLayer.FeatureDTO;
using Restaurant.EntityLayer.Entities;

namespace WebAPI.Mapping
{
    public class FeatureMapping:Profile
    {
        public FeatureMapping()
        {
            CreateMap<Feature,ResultFeatureDTO>().ReverseMap();
            CreateMap<Feature,GetFeatureDTO>().ReverseMap();
            CreateMap<Feature,UpdateFeatureDTO>().ReverseMap();
            CreateMap<Feature,CreateFeatureDTO>().ReverseMap();

        }
    }
}
