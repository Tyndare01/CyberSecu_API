using System.ComponentModel.DataAnnotations;

namespace CyberSecu_API.DTOs
{
    public class ConnectionUserDto
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [StringLength(20, MinimumLength = 8)]
        public string Passwrd { get; set; }
    }
}
