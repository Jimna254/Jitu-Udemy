using Jitu_Udemy.Entities;

namespace Jitu_Udemy.Responses
{
    public class CourseResponse
    {
        public string CourseName { get; set; } = string.Empty;

        public string CourseDescription { get; set; } = string.Empty;

        public Instructor? Instructor { get; set; }

    }
}
