using System.ComponentModel.DataAnnotations.Schema;

namespace Jitu_Udemy.Entities
{
    public class Instructor
    {
        public Guid InstructorId { get; set; }
        public string Name { get; set; } = string.Empty;

        public string Email { get; set; } = string.Empty;

        public int Phone { get; set; } = 0;

       
        public List<Course> Courses { get; set; } = new List<Course>();

       





    }
}
