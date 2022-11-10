using AgendaAPII.Entities;

namespace AgendaAPII.Models.DTO
{
    public class ContactDTO
    {   
        public int? Id { get; set; }
        public string Name { get; set; }
        public List<DispositivoDTO> Dispositivos { get; set; }
        public int UserId { get; set; }
    }
}
