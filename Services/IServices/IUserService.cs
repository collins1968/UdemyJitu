using UdemyJitu.Entities;
using UdemyJitu.Request;

namespace UdemyJitu.Services.IServices
{
    public interface IUserService
    {
        Task<string> AddUserAsync(User user);

        Task<string> UpdateUserAsync(User user);

        Task<string> DeleteUserAsync(User user);

        Task<IEnumerable<User>> GetAllUsersAsync();

        Task<User> GetUserByIdAsync(Guid id);

        Task<string> BuyCourse(BuyCourse buyCourse);
    }
}
