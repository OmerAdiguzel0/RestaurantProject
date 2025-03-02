using AutoMapper;
using Restaurant.DTOLayer.DiscountDTO;
using Restaurant.EntityLayer.Entities;

namespace WebAPI.Mapping
{
    public class DiscountMapping:Profile
    {
        public DiscountMapping()
        {
            CreateMap<Discount,CreateDiscountDTO>().ReverseMap();
            CreateMap<Discount,ResultDiscountDTO>().ReverseMap();
            CreateMap<Discount,GetDiscountDTO>().ReverseMap();
            CreateMap<Discount,UpdateDiscountDTO>().ReverseMap();

        }
    }
}
