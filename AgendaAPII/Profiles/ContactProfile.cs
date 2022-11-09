using AgendaAPII.Entities;
using AgendaAPII.Models.DTO;
using AutoMapper;

namespace AgendaAPII.Profiles

{
    public class ContactProfile : Profile
    {

        public ContactProfile()
        {
            CreateMap<Contact, ContactDTO>();
            CreateMap<ContactDTO, Contact>();

        }
    }
}
