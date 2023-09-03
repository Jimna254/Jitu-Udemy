using System.ComponentModel.DataAnnotations;

namespace Jitu_Udemy.Requests
{
    public class AddInstructor
    {
        [Required]
        public string Name { get; set; } = string.Empty;
        [Required]
        public string Email { get; set; } = string.Empty;
        [Required]
        public int Phone { get; set; } = 0;
    }
}
