using AgendaAPII.Entities;
using AgendaAPII.Models.DTO;

namespace AgendaAPII.Data.Repository.Interfaces
{
    public interface IUserRepository
    {
        Task<List<User>> GetAllUsers();
        Task<User> GetOneById(int id);
        Task DeleteUser(User user);
        Task<User> NewUser(User user);
        Task EditUser(UserDTO userdto);
        public User? ValidateUser(AuthenticationRequestBody authRequestBody);
    }
}
