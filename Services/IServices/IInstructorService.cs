using UdemyJitu.Entities;

namespace UdemyJitu.Services.IServices
{
    public interface IInstructorService
    {
        Task<string> AddInstructorAsync(Instructor instructor);

        Task<string> UpdateInstructorAsync(Instructor instructor);

        Task<string> DeleteInstructorAsync(Instructor instructor);

        Task<IEnumerable<Instructor>> GetAllInstructorsAsync();

        Task<Instructor> GetInstructorByIdAsync(Guid id);

    }
}
