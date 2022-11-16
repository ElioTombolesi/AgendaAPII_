using AgendaAPII.Data.Repository.Interfaces;
using AgendaAPII.Entities;

namespace AgendaAPII.Data.Repository.Implementations
{
    public class DispositivoRepository : IDispositivoRepository
    {
        private readonly AgendaContext _context;

        public DispositivoRepository(AgendaContext context)
        {
            _context = context;
        }
        public async Task<Dispositivo> NewDispositivo(Dispositivo dispositivos)
        {
            _context.Add(dispositivos);
            await _context.SaveChangesAsync();
            return dispositivos;

        }
    }
}
