using System.ComponentModel.DataAnnotations.Schema;

namespace Jitu_Udemy.Entities
{
    public class Course
    {
        public Guid CourseId { get; set; }
        public string CourseName { get; set; } = string.Empty;

        public string CourseDescription { get; set; } = string.Empty;

        [ForeignKey("InstructorId ")]
        public Instructor? Instructor { get; set; }
        public Guid InstructorId { get; set;} = default;

        public List<User> Users { get; set; } = new List<User>();

    }
}
