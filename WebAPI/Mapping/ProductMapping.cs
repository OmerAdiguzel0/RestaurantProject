using AutoMapper;
using Restaurant.DTOLayer.ProductDTO;
using Restaurant.EntityLayer.Entities;

namespace WebAPI.Mapping
{
    public class ProductMapping : Profile
    {
        public ProductMapping()
        {
            CreateMap<Product, GetProductDTO>().ReverseMap();
            CreateMap<Product, UpdateProductDTO>().ReverseMap();
            CreateMap<Product, ResultProductDTO>().ReverseMap();
            CreateMap<Product, CreateProductDTO>().ReverseMap();
            CreateMap<Product, ResultProductWithCategory>()
            //.ForMember(dest => dest.CategoryName, opt => opt.MapFrom(src => src.Category.CategoryName))
            .ReverseMap();

        }
    }
}
