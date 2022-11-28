using AgendaAPII.Data.Repository.Interfaces;
using AgendaAPII.Entities;
using AgendaAPII.Models.DTO;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AgendaAPII.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]

    public class DispositivoController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IDispositivoRepository _dispositivoRepository;
        public DispositivoController(IDispositivoRepository dispositivoRepository, IMapper mapper)
        {

            _mapper = mapper;
            _dispositivoRepository = dispositivoRepository;


        }

        [HttpPost]
        public async Task<IActionResult> NewDispositivo(DispositivoDTO dispositivosDTO)
        {
            try
            {
                var dispositivos = _mapper.Map<Dispositivo>(dispositivosDTO);

                var dispositivoDTO = await _dispositivoRepository.NewDispositivo(dispositivos);

                return NoContent();
            }



            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}
