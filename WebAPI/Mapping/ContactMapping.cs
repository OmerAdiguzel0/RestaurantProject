using AutoMapper;
using Restaurant.DTOLayer.ContactDTO;
using Restaurant.EntityLayer.Entities;

namespace WebAPI.Mapping
{
    public class ContactMapping:Profile
    {
        public ContactMapping()
        {
            CreateMap<Contact, CreateContactDTO>().ReverseMap();
            CreateMap<Contact, UpdateContactDTO>().ReverseMap();
            CreateMap<Contact, ResultContactDTO>().ReverseMap();
            CreateMap<Contact, GetContactDTO>().ReverseMap();

        }
    }
}
