using Microsoft.EntityFrameworkCore;
using UdemyJitu.Data;
using UdemyJitu.Entities;
using UdemyJitu.Services.IServices;

namespace UdemyJitu.Services
{
    public class InstructorService : IInstructorService
    {

        private readonly AppDbContext _context;

        public InstructorService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<string> AddInstructorAsync(Instructor instructor)
        {
            _context.Instructors.Add(instructor);
            await _context.SaveChangesAsync();
            return "User Added Successfully";
        }

        public async Task<string> DeleteInstructorAsync(Instructor instructor)
        {
            _context.Instructors.Remove(instructor);
            await _context.SaveChangesAsync();

            return "User Deleted Successfully";
        }

        public async Task<IEnumerable<Instructor>> GetAllInstructorsAsync()
        {
            var Instructors = await _context.Instructors.ToListAsync();
            return Instructors;
        }

        public async Task<Instructor> GetInstructorByIdAsync(Guid id)
        {
            var instructor = await _context.Instructors.FirstOrDefaultAsync(x => x.Id == id);
            return instructor;
        }

        public async Task<string> UpdateInstructorAsync(Instructor instructor)
        {
            _context.Instructors.Update(instructor);
            await _context.SaveChangesAsync();
            return "Instructor updated Successfully";
        }
    }
}
