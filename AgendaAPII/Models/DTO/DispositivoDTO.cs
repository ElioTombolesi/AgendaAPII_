using AgendaAPII.Enum;
using System.ComponentModel.DataAnnotations;

namespace AgendaAPII.Models.DTO
{
    public class DispositivoDTO


    {
        public int Id { get; set; }
        [Required]
        public string Number { get; set; }
        public int ContactId { get; set; }
        public string? Description { get; set; }
        public string DescriptionType { get { return Types.GetName(typeof(Types), Type); } }// propiedad calculada 

        public Types Type { get; set; }

    }
}
