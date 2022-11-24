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
                var Listcontact = await _contactRepository.GetAllContacts();
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
            var nombre = User.Claims.FirstOrDefault(c => c.Type == System.Security.Claims.ClaimTypes.NameIdentifier)?.Value; 
            try
            {
                var contact = await _contactRepository.GetOneById(id);

                if (contact == null)
                {
                    return NotFound();
                }
                var contactsDTO = _mapper.Map<ContactDTO>(contact);
                return Ok(contactsDTO);


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
                var contact = await _contactRepository.GetOneById(id);

                if (contact == null)
                {
                    return NotFound();
                }

                await _contactRepository.DeleteContact(contact);

                return NoContent();

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
        public async Task<IActionResult> EditContact(int id, ContactDTO contactDTO)
        {
            try
            {
                var contact = _mapper.Map<Contact>(contactDTO);

                if (id != contact.Id)
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





