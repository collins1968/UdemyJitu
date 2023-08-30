using System.ComponentModel.DataAnnotations.Schema;

namespace UdemyJitu.Entities
{
    public class Course
    {
        public Guid Id { get; set; }
        public string  Name { get; set; }

        public string Description { get; set; }

        public int Price { get; set; }

        [ForeignKey("InstructorId")]
        public Instructor Instructor { get; set; } =default!;

        public Guid InstructorId { get; set; }   

        public List<User> users { get; set; } = new List<User>();

    }
}
