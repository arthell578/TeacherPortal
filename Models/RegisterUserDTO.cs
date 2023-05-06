using System.ComponentModel.DataAnnotations;
using TeacherPortal.Entities;

namespace TeacherPortal.Models
{
    public class RegisterUserDTO
    {
        [Required]
        public string Email { get; set; }
        [Required]
        [MinLength(8)]
        public string Password { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        public UserRole UserRole { get; set; } = UserRole.Student;
    }
}
