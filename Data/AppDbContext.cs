using Microsoft.EntityFrameworkCore;
using UdemyJitu.Entities;

namespace UdemyJitu.Data
{
    public class AppDbContext: DbContext
    {

        public DbSet<Course> Courses { get; set; } 
        public DbSet<Instructor> Instructors { get; set; }

        public DbSet<User> Users { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options): base(options)
        {
            
        }
        
    }
}
