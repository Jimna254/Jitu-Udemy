using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Jitu_Udemy.Requests
{
    public class AddUser
    {
        [Required]
        public string UserName { get; set; } = string.Empty;
        [Required]
        [EmailAddress]
        public string UserEmail { get; set; } = string.Empty;
        [Required]
        [MinLength(8)]
        [MaxLength(30)]
        [PasswordPropertyText]
        public string Password { get; set; } = string.Empty;
    }
}
