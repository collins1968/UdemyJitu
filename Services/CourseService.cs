using Microsoft.EntityFrameworkCore;
using UdemyJitu.Data;
using UdemyJitu.Entities;
using UdemyJitu.Services.IServices;

namespace UdemyJitu.Services
{
    public class CourseService : ICoursesService
    {
        private readonly AppDbContext _context;

        public CourseService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<string> CreateCourse(Course course)
        {
            _context.Courses.Add(course);
            await _context.SaveChangesAsync();
            return "Course Added Successfully";
        }

        public async Task<string> DeleteCourse(Course course)
        {
            _context.Courses.Remove(course);
            await _context.SaveChangesAsync();
            return "Course Deleted Successfully";
        }

        public async Task<IEnumerable<Course>> GetAllCourses()
        {
            var courses = await _context.Courses.ToListAsync();
            return courses;
        }

        public async Task<Course> GetCoursebyId(Guid id)
        {
            var task = await _context.Courses.FirstOrDefaultAsync(x => x.Id == id);
            return task;
        }

        public async Task<string> UpdateCourse(Course course)
        {
            _context.Courses.Update(course);
            await _context.SaveChangesAsync();
            return "Course Updated Successfully";
        }
    }
}
