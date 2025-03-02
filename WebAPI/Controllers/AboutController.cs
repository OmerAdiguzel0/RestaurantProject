using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Restaurant.BusinessLayer.Abstract;
using Restaurant.DTOLayer.AboutDTO;
using Restaurant.EntityLayer.Entities;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AboutController : ControllerBase
    {
        private readonly IAboutService _aboutService;

        public AboutController(IAboutService aboutService)
        {
            _aboutService = aboutService;
        }

        [HttpGet]
        public IActionResult AboutList()
        {
            var values = _aboutService.TGetListAll();
            return Ok(values);
        }

        [HttpPost]
        public IActionResult CreateAbout(CreateAboutDTO createAboutDTO)
        {
            About about = new About()
            {
                Description = createAboutDTO.Description,
                ImageURL = createAboutDTO.ImageURL,
                Title = createAboutDTO.Title
            };
            _aboutService.TAdd(about);
            return Ok("Hakkımda kısmı başarılı bir şekilde eklendi.");
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteAbout(int id)
        {
            var value = _aboutService.TGetById(id);
            _aboutService.TDelete(value);
            return Ok("Hakkımda alanı silindi");
        }

        [HttpPut]
        public IActionResult UpdateAbout(UpdateAboutDTO updateAboutDTO)
        {
            About about = new About()
            {
                AboutId=updateAboutDTO.AboutId,
                Description = updateAboutDTO.Description,
                ImageURL = updateAboutDTO.ImageURL,
                Title = updateAboutDTO.Title
            };
            _aboutService.TUpdate(about);
            return Ok("Hakkımda alanı güncellendi");
        }

        [HttpGet("{id}")]
        public IActionResult GetAbout(int id) {
            var value= _aboutService.TGetById(id);
            return Ok(value);
        }
    }
}
