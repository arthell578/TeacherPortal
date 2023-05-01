using System.ComponentModel.DataAnnotations;

namespace TeacherPortal.Models
{
    public class CreateCourseDTO
    {
        [Required]
        [MaxLength(100)]
        public string Name { get; set; }

        [MaxLength(500)]
        public string Description { get; set; }
    }
}
