using System.ComponentModel.DataAnnotations;
using TeacherPortal.Models;

namespace TeacherPortal.Entities
{
    public class Course
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string Name { get; set; }

        [MaxLength(500)]
        public string Description { get; set; }

        public ICollection<Lesson> Lessons { get; set; }
        public ICollection<User> Users { get; set; }
    }
}
