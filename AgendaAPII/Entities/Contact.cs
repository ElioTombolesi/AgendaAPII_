using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AgendaAPII.Entities
{
    public class Contact
    {


        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Name { get; set; }
       
        [ForeignKey("UserId")]
        public User? User { get; set; }
        public int UserId { get; set; }

        public List<Dispositivo> Dispositivos { get; set; }

        

    }
    }


