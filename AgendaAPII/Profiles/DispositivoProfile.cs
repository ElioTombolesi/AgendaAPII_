using AgendaAPII.Entities;
using AgendaAPII.Models.DTO;
using AutoMapper;

namespace AgendaAPII.Profiles
{
    public class DispositivoProfile : Profile
    {

        public DispositivoProfile ()
        {

            CreateMap<Dispositivo, DispositivoDTO>();
            CreateMap<DispositivoDTO, Dispositivo>();
            CreateMap<Dispositivo, DispositiveForCreationDTO>();
            CreateMap<DispositiveForCreationDTO, Dispositivo>();
        }


    }
}
