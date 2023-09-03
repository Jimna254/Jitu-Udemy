using Jitu_Udemy.Entities;

namespace Jitu_Udemy.Responses
{
    public class InstructorResponse
    {
        public string Name { get; set; } = string.Empty;

        public string Email { get; set; } = string.Empty;

        public int Phone { get; set; } = 0;
        public Guid InstructorId { get; set; } = default;

        public List<Course> Courses { get; set; } = new List<Course>();
    }
}
