using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Restaurant.BusinessLayer.Abstract;
using Restaurant.DTOLayer.TestimonialDTO;
using Restaurant.EntityLayer.Entities;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestimonialController : ControllerBase
    {
        private readonly ITestimonialService _testimonialService;
        private readonly IMapper _mapper;

        public TestimonialController(ITestimonialService testimonialService, IMapper mapper)
        {
            _testimonialService = testimonialService;
            _mapper = mapper;
        }


        [HttpGet]
        public IActionResult TestimonialList()
        {
            var value = _mapper.Map<List<ResultTestimonialDTO>>(_testimonialService.TGetListAll());
            return Ok(value);
        }

        [HttpPost]
        public IActionResult CreateTestimonial(CreateTestimonialDTO createTestimonialDTO)
        {
            _testimonialService.TAdd(new Testimonial()
            {
                Comment = createTestimonialDTO.Comment,
                ImagURL=createTestimonialDTO.ImagURL,
                Name = createTestimonialDTO.Name,
                Status = createTestimonialDTO.Status,
                Title = createTestimonialDTO.Title
            });
            return Ok("Müşteri Yorum Bilgisi Eklendi.");
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteTestimonial(int id)
        {
            var value = _testimonialService.TGetById(id);
            _testimonialService.TDelete(value);
            return Ok("Müşteri Yorum Bilgisi Silindi.");
        }

        [HttpGet("{id}")]
        public IActionResult GeTestimonial(int id)
        {
            var value = _testimonialService.TGetById(id);
            return Ok(value);
        }

        [HttpPut]
        public IActionResult UpdateTestimonial(UpdateTestimonialDTO updateTestimonialDTO)
        {
            _testimonialService.TUpdate(new Testimonial()
            {
                Comment = updateTestimonialDTO.Comment,
                ImagURL = updateTestimonialDTO.ImagURL,
                Name = updateTestimonialDTO.Name,
                Status = updateTestimonialDTO.Status,
                Title = updateTestimonialDTO.Title,
                TestimonialId=updateTestimonialDTO.TestimonialId

            });
            return Ok("Müşteri Yorum Bilgisi Güncellendi.");
        }
    }
}
