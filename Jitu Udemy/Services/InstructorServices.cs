using Jitu_Udemy.Data;
using Jitu_Udemy.Entities;
using Jitu_Udemy.Services.IServices;
using Microsoft.EntityFrameworkCore;

namespace Jitu_Udemy.Services
{
    public class InstructorServices : IInstructorSevices
    {
        private AppDbContext _context;
        public InstructorServices(AppDbContext _appDbContext) {

            _context = _appDbContext;
        }
        public async Task<string> AddInstructorAsync(Instructor instructor)
        {
           _context.Instructors.Add(instructor);
            await _context.SaveChangesAsync();
            return "Instructor Added Succesfully";
        }

        public async Task<string> DeleteInstructorAsync(Instructor instructor)
        {
            _context?.Instructors.Remove(instructor);
            await _context.SaveChangesAsync();
            return $"{nameof(Instructor)} Has been Deleted Succesfully";
        }

        public async Task<ICollection<Instructor>> GetAllInstructorsAsync()
        {
            return await _context.Instructors.ToListAsync();

        }

        public async Task<Instructor> GetInsructorAsync(Guid id)
        {
            return await _context.Instructors.Where(i => i.InstructorId == id).FirstOrDefaultAsync();
        }

        public async Task<string> UpdateInstructorAsync(Instructor instructor)
        {
            _context.Instructors.Update(instructor);
            await _context.SaveChangesAsync();
            return $"{nameof(Instructor)} Has been Succesfully Updated";
        }
    }
}
