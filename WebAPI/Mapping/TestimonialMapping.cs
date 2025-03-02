using AutoMapper;
using Restaurant.DTOLayer.AboutDTO;
using Restaurant.DTOLayer.TestimonialDTO;
using Restaurant.EntityLayer.Entities;

namespace WebAPI.Mapping
{
    public class TestimonialMapping:Profile
    {
        public TestimonialMapping()
        {
            CreateMap<Testimonial, CreateTestimonialDTO>().ReverseMap();
            CreateMap<Testimonial, UpdateTestimonialDTO>().ReverseMap();
            CreateMap<Testimonial, GetTestimonialDTO>().ReverseMap();
            CreateMap<Testimonial, ResultTestimonialDTO>().ReverseMap();

        }
    }
}
