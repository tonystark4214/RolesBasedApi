using System.ComponentModel.DataAnnotations;

namespace Project220723.Models
{
    public class Credentials
    {
        [Required]
        public string Username { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
