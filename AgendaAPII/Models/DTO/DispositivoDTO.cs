using AgendaAPII.Enum;

namespace AgendaAPII.Models.DTO
{
    public class DispositivoDTO
    {
       public string Number { get; set; }
        public int Id { get; set; }
        public string? Description { get; set; }
        public string DescriptionType { get { return Types.GetName(typeof(Types), Type); } }// propiedad calculada 

        public Types Type { get; set; }

    }
}
