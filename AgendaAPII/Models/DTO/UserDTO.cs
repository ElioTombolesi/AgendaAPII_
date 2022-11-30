using System.ComponentModel.DataAnnotations;

namespace AgendaAPII.Models.DTO
{
    public class UserDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        [Required]
        public string Password { get; set; }
        public string Email { get; set; }
        [Required]
        public string UserName { get; set; }

        
    }
}
