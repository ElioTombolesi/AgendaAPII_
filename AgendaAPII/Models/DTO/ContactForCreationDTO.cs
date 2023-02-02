namespace AgendaAPII.Models.DTO
{
    public class ContactForCreationDTO
    {
        public string Name{ get; set; }
        public List<DispositiveForCreationDTO> Dispositivos { get; set; }

        public int UserId { get; set; }
    }
}
