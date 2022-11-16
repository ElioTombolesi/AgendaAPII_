using AgendaAPII.Entities;

namespace AgendaAPII.Data.Repository.Interfaces
{
    public interface IDispositivoRepository
    {
        Task<Dispositivo> NewDispositivo(Dispositivo dispositivos);
    }
}
