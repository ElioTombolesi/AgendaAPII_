namespace AgendaAPII.Models.DTO
{
    public class ContactForEditDTO
    {
        public int? Id { get; set; }
        public string Name { get; set; }
        public List<DispositivoDTO>? Dispositivos { get; set; }
    }
}
