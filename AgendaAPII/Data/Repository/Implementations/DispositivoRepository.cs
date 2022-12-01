using AgendaAPII.Data.Repository.Interfaces;
using AgendaAPII.Entities;
using Microsoft.EntityFrameworkCore;

namespace AgendaAPII.Data.Repository.Implementations
{
    public class DispositivoRepository : IDispositivoRepository
    {
        private readonly AgendaContext _context;

        public DispositivoRepository(AgendaContext context)
        {
            _context = context;
        }

        public async Task DeleteDispositivo(Dispositivo dispositivo)
        {
            _context.Dispositivos.Remove(dispositivo);
            await _context.SaveChangesAsync();
        }

        public async Task<Dispositivo> GetOneById(int id)
        {

            return await _context.Dispositivos.Where(x => x.Id == id).Include(x => x.Contact).FirstOrDefaultAsync();



        }



        public async Task<List<Dispositivo>> GetAllDispositivo(int UserId)

        {
            
            return await _context.Dispositivos.Where(x => x.Contact.UserId == UserId).ToListAsync();

        }

        public async Task<Dispositivo> NewDispositivo(Dispositivo dispositivos)
        {
            _context.Add(dispositivos);
            await _context.SaveChangesAsync();
            return dispositivos;

        }
    }
}
