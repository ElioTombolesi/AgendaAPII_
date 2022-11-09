using AgendaAPII.Entities;

namespace AgendaAPII.Models.DTO
{
    public class ContactDTO
    {   
        public int? Id { get; set; }
        public string Name { get; set; }
        public int? CelularNumber { get; set; }
        public int? TelephoneNumber { get; set; }
        public int UserId { get; set; }
    }
}
