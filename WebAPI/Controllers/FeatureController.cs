using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Restaurant.BusinessLayer.Abstract;
using Restaurant.DTOLayer.FeatureDTO;
using Restaurant.EntityLayer.Entities;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FeatureController : ControllerBase
    {
        private readonly IFeatureService _featureService;
        private readonly IMapper _mapper;

        public FeatureController(IFeatureService featureService, IMapper mapper)
        {
            _featureService = featureService;
            _mapper = mapper;
        }


        [HttpGet]
        public IActionResult FeatureList()
        {
            var value = _mapper.Map<List<ResultFeatureDTO>>(_featureService.TGetListAll());
            return Ok(value);
        }

        [HttpPost]
        public IActionResult CreateFeature(CreateFeatureDTO createFeatureDTO)
        {
            _featureService.TAdd(new Feature()
            {
                Description1 = createFeatureDTO.Description1,
                Description2 = createFeatureDTO.Description2,
                Description3 = createFeatureDTO.Description3,
                Title1 = createFeatureDTO.Title1,
                Title2 = createFeatureDTO.Title2,
                Title3 = createFeatureDTO.Title3
            });
            return Ok("Öne Çıkan Bilgisi Eklendi.");
        }

        [HttpDelete]
        public IActionResult DeleteFeature(int id)
        {
            var value = _featureService.TGetById(id);
            _featureService.TDelete(value);
            return Ok("Öne Çıkan Bilgisi Silindi");
        }

        [HttpGet("GetFeature")]
        public IActionResult GeFeature(int id)
        {
            var value = _featureService.TGetById(id);
            return Ok(value);
        }

        [HttpPut]
        public IActionResult UpdateFeature(UpdateFeatureDTO updateFeatureDTO)
        {
            _featureService.TUpdate(new Feature()
            {
                Description1 = updateFeatureDTO.Description1,
                Description2 = updateFeatureDTO.Description2,
                Description3 = updateFeatureDTO.Description3,
                FeatureId=updateFeatureDTO.FeatureId,
                Title1 = updateFeatureDTO.Title1,
                Title2 = updateFeatureDTO.Title2,
                Title3 = updateFeatureDTO.Title3,
            });
            return Ok("Öne Çıkan Bilgisi Güncellendi.");
        }
    }
}
