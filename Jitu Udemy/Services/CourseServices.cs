using Jitu_Udemy.Data;
using Jitu_Udemy.Entities;
using Jitu_Udemy.Services.IServices;
using Microsoft.EntityFrameworkCore;

namespace Jitu_Udemy.Services
{
    public class CourseServices : ICourseServices
    {
        private AppDbContext _context;
        public CourseServices(AppDbContext _appDbContext) { 
        
        _context = _appDbContext;
        
        }
        public async Task<string> AddCourseAsync(Course course)
        { 
            _context.Add(course);
            await _context.SaveChangesAsync();
            return "Course Added Succesfully";
            
        }

        public async Task<string> DeleteCourseAsync(Course course)
        {
            _context.Courses.Remove(course);
            await _context.SaveChangesAsync();
            return "Course Deleted Succefully";
        }

        public async Task<ICollection<Course>> GetAllCoursesAsync()
        {
           return await _context.Courses.ToListAsync();
            
        }
        public async Task<Course> GetCourseAsync(Guid id)
        {
            return await _context.Courses.Where(c => c.CourseId == id).FirstOrDefaultAsync();
        }


        public async Task<string> UpdateCourseAsync(Course course)
        {
            _context.Courses.Update(course);
            await _context.SaveChangesAsync();
            return "CourseUpdatedSuccesfully";


        }
    }
}
