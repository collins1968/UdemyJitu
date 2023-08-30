using System.ComponentModel.DataAnnotations;

namespace UdemyJitu.Request
{
    public class AddInstructor
    {
            [Required]
            public string Name { get; set; } = string.Empty;
            [Required]
            [EmailAddress]
            public string Email { get; set; } = string.Empty;
            public string Password { get; set; } = string.Empty;
        
    }
}
