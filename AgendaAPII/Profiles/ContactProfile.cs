using AgendaAPII.Entities;
using AgendaAPII.Models.DTO;
using AutoMapper;

namespace AgendaAPII.Profiles

{
    public class ContactProfile : Profile
    {

        public ContactProfile()
        {
            CreateMap<Contact, ContactForEditDTO>();
            CreateMap<ContactForEditDTO, Contact>();
            CreateMap<Contact, ContactDTO>();
            CreateMap<ContactDTO, Contact>();
            

        }
    }
}
