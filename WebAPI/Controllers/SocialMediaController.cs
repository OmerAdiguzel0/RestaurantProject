using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Restaurant.BusinessLayer.Abstract;
using Restaurant.DTOLayer.SocialMediaDTO;
using Restaurant.EntityLayer.Entities;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SocialMediaController : ControllerBase
    {
        private readonly ISocialMediaService _socialMediaService;
        private readonly IMapper _mapper;

        public SocialMediaController(ISocialMediaService socialMediaService, IMapper mapper)
        {
            _socialMediaService = socialMediaService;
            _mapper = mapper;
        }


        [HttpGet]
        public IActionResult SocialMediaList()
        {
            var value = _mapper.Map<List<ResultSocialMediaDTO>>(_socialMediaService.TGetListAll());
            return Ok(value);
        }

        [HttpPost]
        public IActionResult CreateSocialMedia(CreateSocialMediaDTO createSocialMediaDTO)
        {
            _socialMediaService.TAdd(new SocialMedia()
            {
                Title = createSocialMediaDTO.Title,
                Icon = createSocialMediaDTO.Icon,
                Url = createSocialMediaDTO.Url
            });
            return Ok("Sosyal Medya Bilgisi Eklendi.");
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteSocialMedia(int id)
        {
            var value = _socialMediaService.TGetById(id);
            _socialMediaService.TDelete(value);
            return Ok("Sosyal Medya Bilgisi Silindi.");
        }

        [HttpGet("{id}")]
        public IActionResult GeSocialMedia(int id)
        {
            var value = _socialMediaService.TGetById(id);
            return Ok(value);
        }

        [HttpPut]
        public IActionResult UpdateSocialMedia(UpdateSocialMediaDTO updateSocialMediaDTO)
        {
            _socialMediaService.TUpdate(new SocialMedia()
            {
                Title = updateSocialMediaDTO.Title,
                Icon = updateSocialMediaDTO.Icon,
                SocialMediaId = updateSocialMediaDTO.SocialMediaId,
                Url= updateSocialMediaDTO.Url

            });
            return Ok("Sosyal Medya Bilgisi Güncellendi.");
        }
    }
}
