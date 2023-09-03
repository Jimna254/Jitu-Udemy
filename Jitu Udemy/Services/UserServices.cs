using Jitu_Udemy.Data;
using Jitu_Udemy.Entities;
using Jitu_Udemy.Requests;
using Jitu_Udemy.Services.IServices;
using Microsoft.EntityFrameworkCore;

namespace Jitu_Udemy.Services
{
    public class UserServices : IUserServices
    {
        private AppDbContext _context ;
        public UserServices(AppDbContext _appDbContext)
        {
            _context = _appDbContext;   
        }
        public async Task<string> AddUserAsync(User user)
        {
           _context.Users.Add(user);
            await _context.SaveChangesAsync();
            return "User Created Succesfully";
        }

        public Task<string> BuyCourse(BuyCourse buyCourse)
        {
            throw new NotImplementedException();
        }

        public async Task<ICollection<User>> GetAllUsersAsync()
        {
           return await _context.Users.ToListAsync();
        }

        public async Task<User> GetUserAsync(Guid Userid)
        {
            return await _context.Users.Where(u => u.UserId == Userid).FirstOrDefaultAsync();
        }

        public async Task<string> DeleteUserAsync(User user)
        {
            _context.Users.Remove(user);
            await _context.SaveChangesAsync();
            return "User Deleted Successfully";
        }


        public async Task<string> UpdateUserAsync(User user)
        {
            _context.Users.Update(user);
            await _context.SaveChangesAsync();
            return "User Updated Succesfully";
        }
    }
}
