using System.ComponentModel.DataAnnotations;

namespace TeacherPortal.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(25)]
        public string FirstName { get; set; }

        [Required]
        [MaxLength(25)]
        public string LastName { get; set; }

        [Required]
        [EmailAddress]
        [MaxLength(30)]
        public string Email { get; set; }

        [Required]
        [MaxLength(40)]
        public string Password { get; set; }

        public UserRole UserRole { get; set; }
        public ICollection<Course> Courses { get; set; }
    }
}
