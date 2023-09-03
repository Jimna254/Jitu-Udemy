using Jitu_Udemy.Entities;

namespace Jitu_Udemy.Services.IServices
{
    public interface IInstructorSevices
    {
        Task<string> AddInstructorAsync(Instructor instructor);

        Task<string> UpdateInstructorAsync(Instructor instructor);

        Task<string> DeleteInstructorAsync(Instructor instructor);

        Task<Instructor> GetInsructorAsync(Guid InstructorId);

        Task<ICollection<Instructor>> GetAllInstructorsAsync();
    }
}
