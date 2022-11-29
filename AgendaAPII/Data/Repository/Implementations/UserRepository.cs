using AgendaAPII.Data.Repository.Interfaces;
using AgendaAPII.Entities;
using AgendaAPII.Models.DTO;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace AgendaAPII.Data.Repository.Implementations
{
    public class UserRepository : IUserRepository

    {

        private readonly AgendaContext _context;
        private readonly IMapper _mapper;

        public UserRepository(AgendaContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;

        }
        public async Task DeleteUser(User user)
        {
            _context.Users.Remove(user);
            await _context.SaveChangesAsync();
        }

        public async Task EditUser(UserDTO userdto)
        {

            var user = _mapper.Map<User>(userdto);
            _context.Users.Update(user);
                    
               await _context.SaveChangesAsync();






        }

        public async Task<List<User>> GetAllUsers()
        {

            return await _context.Users.ToListAsync();
        }

        public async Task<User> GetOneById(int id)
        {
             return await _context.Users.FindAsync(id);
        }

        public async Task<User> NewUser(User user)
        {

            _context.Add(user);
            await _context.SaveChangesAsync();
            return user;
        }

        public User? ValidateUser(AuthenticationRequestBody authRequestBody)
        {
            return _context.Users.FirstOrDefault(p => p.UserName == authRequestBody.UserName && p.Password == authRequestBody.Password);
        }

    }
}