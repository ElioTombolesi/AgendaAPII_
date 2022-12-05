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

        [HttpGet]

        public async Task<IActionResult> GetAllDispositivo()
        {
            try
            {
                int userId = Int32.Parse(User.Claims.FirstOrDefault(c => c.Type == System.Security.Claims.ClaimTypes.NameIdentifier)?.Value);
               
                var Listdispositivos = await _dispositivoRepository.GetAllDispositivo(userId); 
                var ListdispositivosDTO = _mapper.Map<IEnumerable<DispositivoDTO>>(Listdispositivos);
                return Ok(ListdispositivosDTO);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }


        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetOneById(int id)
        {
            try
            {
                int UserId = Int32.Parse(User.Claims.FirstOrDefault(c => c.Type == System.Security.Claims.ClaimTypes.NameIdentifier)?.Value);

                var dispositivo = await _dispositivoRepository.GetOneById(id); 
                if (dispositivo == null)
                {
                    return NotFound();
                }
                if (dispositivo.Contact.UserId == UserId)
                {
                    var DispositivoDTO = _mapper.Map<DispositivoDTO>(dispositivo);
                    return Ok(DispositivoDTO);
                }
                return NotFound();


            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }

        }

        [HttpDelete("{id}")]

        public async Task<IActionResult> DeleteDeleteDispositivo(int id)
        {
            try
            {
                int UserId = Int32.Parse(User.Claims.FirstOrDefault(c => c.Type == System.Security.Claims.ClaimTypes.NameIdentifier)?.Value);


                var dispositivo = await _dispositivoRepository.GetOneById(id);
                if (dispositivo == null)
                {
                    return NotFound();
                }
                if (dispositivo.Contact.UserId == UserId)
                {
                    await _dispositivoRepository.DeleteDispositivo(dispositivo);
                    return NoContent();
                }
                return NotFound();
                


                

            }
            catch (Exception ex)

            {

                return BadRequest(ex.Message);
            }

        }






    }
}
