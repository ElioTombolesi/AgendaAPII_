using AgendaAPII.Data.Repository.Interfaces;
using AgendaAPII.Entities;
using Microsoft.EntityFrameworkCore;

namespace AgendaAPII.Data.Repository.Implementations
{
    public class UserRepository : IUserRepository

    {

        private readonly AgendaContext _context;

        public UserRepository(AgendaContext context)
        {
            _context = context;
        }
        public async Task DeleteUser(User user)
        {
            _context.Users.Remove(user);
            await _context.SaveChangesAsync();
        }

        public async Task EditUser(User user)
        {
            var userEdit = await _context.Users.FirstOrDefaultAsync(x => x.Id == user.Id);

            if (userEdit != null)
            {


                userEdit.Name = user.Name;
                userEdit.LastName = user.LastName;
                userEdit.Password = user.Password;
                userEdit.Email = user.Email;
                userEdit.UserName = user.UserName;



                await _context.SaveChangesAsync();

                

            }
            
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


    }
}