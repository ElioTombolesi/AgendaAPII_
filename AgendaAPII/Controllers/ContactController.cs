using AgendaAPII.Data.Repository.Interfaces;
using AgendaAPII.Entities;
using AgendaAPII.Models.DTO;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AgendaAPII.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]

    public class ContactController : ControllerBase
    {

        private readonly IMapper _mapper;
        private readonly IContactRepository _contactRepository;
        public ContactController(IContactRepository contactRepository, IMapper mapper)
        {

            _mapper = mapper;
            _contactRepository = contactRepository;


        }

        [HttpGet]
        public async Task<IActionResult> GetAllContacts()
        {
            try
            {
                int UserId =Int32.Parse(User.Claims.FirstOrDefault(c => c.Type == System.Security.Claims.ClaimTypes.NameIdentifier)?.Value);
                var Listcontact = await _contactRepository.GetAllContacts(UserId);
                var ListcontactsDTO = _mapper.Map<IEnumerable<ContactDTO>>(Listcontact);
                return Ok(ListcontactsDTO);
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

                var contact = await _contactRepository.GetOneById(id);

                if (contact == null)
                {
                    return NotFound();
                }
                if (contact.UserId == UserId)
                {
                    var contactsDTO = _mapper.Map<ContactDTO>(contact);
                    return Ok(contactsDTO);
                }
                return NotFound();


            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }

        }

        [HttpDelete("{id}")]

        public async Task<IActionResult> DeleteContact(int id)
        {
            try
            {
                int UserId = Int32.Parse(User.Claims.FirstOrDefault(c => c.Type == System.Security.Claims.ClaimTypes.NameIdentifier)?.Value);

                var contact = await _contactRepository.GetOneById(id);

                if (contact == null)
                {
                    return NotFound();
                }
                if (contact.UserId == UserId)
                {
                    await _contactRepository.DeleteContact(contact);

                    return NoContent();
                }


                return NotFound();

            }
            catch (Exception ex)

            {

                return BadRequest(ex.Message);
            }

        }

        [HttpPost]

        public async Task<IActionResult> NewContact(ContactDTO contactDTO)
        {
            try
            {
                int UserId = Int32.Parse(User.Claims.FirstOrDefault(c => c.Type == System.Security.Claims.ClaimTypes.NameIdentifier)?.Value);

                if ( contactDTO.UserId != UserId)
                {
                    return BadRequest();
                }

                var contact = _mapper.Map<Contact>(contactDTO);

                var contactt = await _contactRepository.NewContact(contact);

                return Ok();

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> EditContact(int id, ContactDTO ContactForEditDTO)
        {
            try
            {
                int UserId = Int32.Parse(User.Claims.FirstOrDefault(c => c.Type == System.Security.Claims.ClaimTypes.NameIdentifier)?.Value);

                var contact = _mapper.Map<Contact>(ContactForEditDTO);

                if (id != contact.Id || contact.UserId != UserId)
                {
                    return BadRequest();
                }

                var contactEdit = await _contactRepository.GetOneById(id);

                if (contactEdit == null)
                {
                    return NotFound();
                }

                await _contactRepository.EditContact(contact);

                return NoContent();

            }


            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


    }
}





