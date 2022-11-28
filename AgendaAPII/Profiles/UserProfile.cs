using AgendaAPII.Entities;
using AgendaAPII.Models.DTO;
using AutoMapper;

namespace AgendaAPII.Profiles
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<User, UserDTO>();
            CreateMap<UserDTO, User>();
            CreateMap<User, GetUserDTO>();
            CreateMap<GetUserDTO, User>();


        }


    }
}
