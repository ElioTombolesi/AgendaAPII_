using AgendaAPII.Entities;

namespace AgendaAPII.Data.Repository.Interfaces
{
    public interface IDispositivoRepository
    {
        Task<Dispositivo> NewDispositivo(Dispositivo dispositivos);
        Task<List<Dispositivo>> GetAllDispositivo(int UserId);
        Task DeleteDispositivo(Dispositivo dispositivo);
        Task<Dispositivo> GetOneById(int id);


    }
}
