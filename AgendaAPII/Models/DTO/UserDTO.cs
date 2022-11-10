﻿using System.ComponentModel.DataAnnotations;

namespace AgendaAPII.Models.DTO
{
    public class UserDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Password { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string UserName { get; set; }

        public ICollection<ContactDTO> Contacts { get; set; }
    }
}
