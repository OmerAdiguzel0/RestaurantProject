using AutoMapper;
using Restaurant.DTOLayer.CategoryDTO;
using Restaurant.EntityLayer.Entities;

namespace WebAPI.Mapping
{
    public class CategoryMapping:Profile
    {
        public CategoryMapping()
        {
            CreateMap<Category,ResultCategoryDTO>().ReverseMap();
            CreateMap<Category,GetCategoryDTO>().ReverseMap();
            CreateMap<Category,UpdateCategoryDTO>().ReverseMap();
            CreateMap<Category,CreateCategoryDTO>().ReverseMap();
        }
    }
}
