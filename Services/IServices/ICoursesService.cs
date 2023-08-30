using UdemyJitu.Entities;

namespace UdemyJitu.Services.IServices
{
    public interface ICoursesService
    {
        Task<string> CreateCourse(Course course);
        Task<string> UpdateCourse(Course course);
        Task<Course> GetCoursebyId(Guid id);
        Task<string> DeleteCourse(Course course);
        Task<IEnumerable<Course>> GetAllCourses();

    }
}
