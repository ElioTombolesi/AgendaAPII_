using AgendaAPII.Entities;
using Microsoft.EntityFrameworkCore;

namespace AgendaAPII
{
    public class AgendaContext : DbContext
    {
        public DbSet<User> Users { get; set; }//tablas
        public DbSet<Contact> Contacts { get; set; }

        public AgendaContext (DbContextOptions<AgendaContext> options): base(options) // constructor
        {


        }

    }
}
