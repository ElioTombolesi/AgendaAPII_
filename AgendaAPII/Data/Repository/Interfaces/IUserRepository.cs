using AgendaAPII.Entities;

namespace AgendaAPII.Data.Repository.Interfaces
{
    public interface IUserRepository
    {
        Task<List<User>> GetAllUsers();

        Task<User> GetOneById(int id);

        Task DeleteUser(User user);

        Task<User> NewUser(User user);

        Task EditUser(User user);
    }
}
