using AgendaAPII.Enum;
using System.ComponentModel.DataAnnotations;

namespace AgendaAPII.Models.DTO
{
    public class DispositiveForCreationDTO
    {

        [Required]
        public string Number { get; set; }
        public string? Description { get; set; }
        public string DescriptionType { get { return Types.GetName(typeof(Types), Type); } }// propiedad calculada 

        public Types Type { get; set; }
    }
}

