using Jitu_Udemy.Entities;
using Jitu_Udemy.Requests;

namespace Jitu_Udemy.Services.IServices
{
    public interface ICourseServices
    {
        
        Task<string> AddCourseAsync(Course course);

        Task<string> UpdateCourseAsync(Course course);

        Task<string> DeleteCourseAsync(Course course);

        Task<Course> GetCourseAsync(Guid CourseId);

        Task<ICollection<Course>> GetAllCoursesAsync();

    }
}
