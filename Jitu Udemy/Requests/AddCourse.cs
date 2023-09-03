namespace Jitu_Udemy.Requests
{
    public class AddCourse
    {
        public string CourseName { get; set; } = string.Empty;

        public string CourseDescription { get; set; } = string.Empty;

        public Guid InstructorId { get; set; } = default;
    }
}
