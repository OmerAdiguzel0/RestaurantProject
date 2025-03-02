using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Restaurant.BusinessLayer.Abstract;
using Restaurant.DTOLayer.CategoryDTO;
using Restaurant.EntityLayer.Entities;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {

        private readonly ICategoryService _categoryService;
        private readonly IMapper _mapper;

        public CategoryController(ICategoryService categoryService, IMapper mapper)
        {
            _categoryService = categoryService;
            _mapper = mapper;
        }


        [HttpGet]
        public IActionResult CategoryList()
        {
            var value = _mapper.Map<List<ResultCategoryDTO>>(_categoryService.TGetListAll());
            return Ok(value);
        }

        [HttpPost]
        public IActionResult CreateCategory(CreateCategoryDTO createCategoryDTO)
        {
            _categoryService.TAdd(new Category()
            {
                CategoryName = createCategoryDTO.CategoryName,
                CategoryStatus = true
            });
            return Ok("Kategori Eklendi.");
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteCategory(int id) 
        {
            var value = _categoryService.TGetById(id);
            _categoryService.TDelete(value);
            return Ok("Kategori Silindi");
        }

        [HttpGet("{id}")]
        public IActionResult GetCategory(int id) 
        {
            var value = _categoryService.TGetById(id);
            return Ok(value);
        }

        [HttpPut]
        public IActionResult UpdateCategory(UpdateCategoryDTO updateCategoryDTO)
        {
            _categoryService.TUpdate(new Category()
            {
                CategoryId = updateCategoryDTO.CategoryId,
                CategoryName = updateCategoryDTO.CategoryName,
                CategoryStatus = updateCategoryDTO.CategoryStatus
            });
            return Ok("Kategori Güncellendi.");
        }

    }
}
