using AutoMapper;
using Restaurant.DTOLayer.BookingDTO;
using Restaurant.EntityLayer.Entities;

namespace WebAPI.Mapping
{
    public class BookingMapping:Profile
    {
        public BookingMapping()
        {
            CreateMap<Booking,CreateBookingDTO>().ReverseMap();
            CreateMap<Booking,UpdateBookingDTO>().ReverseMap();
            CreateMap<Booking,ResultBookingDTO>().ReverseMap();
            CreateMap<Booking,GetBookingDTO>().ReverseMap();

        }
    }
}
