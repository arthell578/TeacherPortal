using System.ComponentModel.DataAnnotations;

namespace TeacherPortal.Models
{
    public class UpdateCourseDTO
    {
        [Required]
        [MaxLength(100)]
        public string Name { get; set; }

        [MaxLength(500)]
        public string Description { get; set; }
    }
}
