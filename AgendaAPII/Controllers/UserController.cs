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

    public class UserController : ControllerBase
    {


        private readonly IMapper _mapper;
        private readonly IUserRepository _userRepository;


        public UserController(IMapper mapper, IUserRepository userRepository)
        {
            _mapper = mapper;
            _userRepository = userRepository;



        }



        [HttpGet]

        public async Task<IActionResult> GetAllUsers()
        {
            try
            {
                var Listuser = await _userRepository.GetAllUsers();
                var ListuserDTO = _mapper.Map<IEnumerable<GetUserDTO>>(Listuser);

                return Ok(ListuserDTO);


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
                var user = await _userRepository.GetOneById(id);

                if (user == null)
                {
                    return NotFound();
                }
                var userDTO = _mapper.Map<GetUserDTO>(user);
                return Ok(userDTO);

            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }

        }
        [HttpDelete("{id}")]

        public async Task<IActionResult> DeleteUser(int id)
        {
            try
            {
                var user = await _userRepository.GetOneById(id);

                if (user == null)
                {
                    return NotFound();
                }

                await _userRepository.DeleteUser(user);

                return NoContent();

            }
            catch (Exception ex)

            {

                return BadRequest(ex.Message);
            }

        }

        [HttpPost]

        public async Task<IActionResult> NewUser(UserDTO userDTO)
        {
            try
            {
                var user = _mapper.Map<User>(userDTO);

                var userr = await _userRepository.NewUser(user);

                var userItem = _mapper.Map<UserDTO>(userr);
                return Ok();
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }

        }

        [HttpPut]
        public async Task<IActionResult> EditUser( UserDTO userdto)
        {
            try
            {
                int UserId = Int32.Parse(User.Claims.FirstOrDefault(c => c.Type == System.Security.Claims.ClaimTypes.NameIdentifier)?.Value);


                if (UserId != userdto.Id)
                {
                    return BadRequest();
                }

                

                await _userRepository.EditUser(userdto);

                return NoContent();

            }


            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }



        }


    }


}


