using AgendaAPII.Enum;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AgendaAPII.Entities
{
    public class Dispositivo
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int Number { get; set; }

        public int ContactId { get; set; }
        [ForeignKey("ContactId")]

        public Contact? Contact { get; set; }
        public string? Description { get; set; }

        public Types Type { get; set; } 

    }
}
