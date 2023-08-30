using Microsoft.EntityFrameworkCore;
using UdemyJitu.Data;
using UdemyJitu.Entities;
using UdemyJitu.Request;
using UdemyJitu.Services.IServices;

namespace UdemyJitu.Services
{
    public class UserService : IUserService
    {

        private readonly AppDbContext _context;

        public UserService(AppDbContext context)
        {
            _context = context;
        }
        public async Task<string> AddUserAsync(User user)
        {
            _context.Users.Add(user);
            await _context.SaveChangesAsync();
            return "User Added Successfully";

        }

        public Task<string> BuyCourse(BuyCourse buyCourse)
        {
            throw new NotImplementedException();
        }

        public async Task<string> DeleteUserAsync(User user)
        {
            _context.Users.Remove(user);
            await _context.SaveChangesAsync();
            return "User Deleted Successfully";
        }

        public async Task<IEnumerable<User>> GetAllUsersAsync()
        {
            return await _context.Users.ToListAsync();
        }

        public async Task<User> GetUserByIdAsync(Guid id)
        {
            var user = await _context.Users.FirstOrDefaultAsync(x => x.Id == id);
            return user;
        }

        public async Task<string> UpdateUserAsync(User user)
        {
            _context.Users.Update(user);
            await _context.SaveChangesAsync();
            return "User Added Successfully";
        }
    }
}
