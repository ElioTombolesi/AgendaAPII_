using AgendaAPII.Entities;

namespace AgendaAPII.Data.Repository.Interfaces
{
    public interface IContactRepository
    {

         Task<List<Contact>> GetAllContacts(int UserId);

        Task<Contact?> GetOneById(int id);

        Task DeleteContact(Contact contact);

        Task <Contact> NewContact(Contact contact);

        Task EditContact(Contact contact);

        
    }


}
