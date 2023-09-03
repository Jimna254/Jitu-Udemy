namespace Jitu_Udemy.Entities
{
    public class User
    {
        public Guid UserId { get; set; }

        public string UserName { get; set; } = string.Empty;

        public string UserEmail { get; set; } = string.Empty;

        public string Password { get; set; } = string.Empty;

        public IEnumerable<Course> Courses { get; set; } = new List<Course>();


    }
}
