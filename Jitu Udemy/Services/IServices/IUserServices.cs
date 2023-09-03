using Jitu_Udemy.Entities;
using Jitu_Udemy.Requests;

namespace Jitu_Udemy.Services.IServices
{
    public interface IUserServices
    {
        //Addding a User
        Task<string> AddUserAsync(User user);

        Task<string> UpdateUserAsync(User user);

        Task<string> DeleteUserAsync(User user);

        Task<User> GetUserAsync(Guid Userid);

        Task<ICollection<User>> GetAllUsersAsync();

        Task<string> BuyCourse(BuyCourse buyCourse);


    }
}
