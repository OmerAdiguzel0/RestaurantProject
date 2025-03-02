using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Restaurant.BusinessLayer.Abstract;
using Restaurant.DataAccessLayer.Concrete;
using Restaurant.DTOLayer.ProductDTO;
using Restaurant.EntityLayer.Entities;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {

        private readonly IProductService _productService;
        private readonly IMapper _mapper;

        public ProductController(IProductService productService, IMapper mapper)
        {
            _productService = productService;
            _mapper = mapper;
        }


        [HttpGet]
        public IActionResult ProductList()
        {
            var value = _mapper.Map<List<ResultProductDTO>>(_productService.TGetListAll());
            return Ok(value);
        }


        [HttpGet("ProductListWithCategory")]
        public IActionResult ProductListWithCategory()
        {
            var context = new RestaurantContext();
            var values = context.Products.Include(x => x.Category).Select(y => new ResultProductWithCategory
            {
                ProductId = y.ProductId,
                ProductName = y.ProductName,
                Description = y.Description,
                Price = y.Price,
                ImageURL = y.ImageURL,
                ProductStatus = y.ProductStatus,
                CategoryName = y.Category.CategoryName
            }).ToList();
            return Ok(values.ToList());
        }

        [HttpPost]
        public IActionResult CreateProduct(CreateProductDTO createProductDTO)
        {
            _productService.TAdd(new Product()
            {
                Description = createProductDTO.Description,
                ImageURL = createProductDTO.ImageURL,
                Price = createProductDTO.Price,
                ProductName = createProductDTO.ProductName,
                ProductStatus = createProductDTO.ProductStatus,
                CategoryId = createProductDTO.CategoryId
            });
            return Ok("Ürün Eklendi.");
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteProduct(int id)
        {
            var value = _productService.TGetById(id);
            _productService.TDelete(value);
            return Ok("Ürün Silindi");
        }

        [HttpGet("{id}")]
        public IActionResult GeProduct(int id)
        {
            var value = _productService.TGetById(id);
            return Ok(value);
        }

        [HttpPut]
        public IActionResult UpdateProduct(UpdateProductDTO updateProductDTO)
        {
            _productService.TUpdate(new Product()
            {
                Description = updateProductDTO.Description,
                ImageURL = updateProductDTO.ImageURL,
                Price = updateProductDTO.Price,
                ProductId = updateProductDTO.ProductId,
                ProductName = updateProductDTO.ProductName,
                ProductStatus = updateProductDTO.ProductStatus,
                CategoryId = updateProductDTO.CategoryId

            });
            return Ok("Ürün Güncellendi.");
        }


    }
}
