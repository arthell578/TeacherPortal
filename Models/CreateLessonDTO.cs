using System.ComponentModel.DataAnnotations;

namespace TeacherPortal.Models
{
    public class CreateLessonDTO
    {
        [Required]
        [MaxLength(100)]
        public string Title { get; set; }

        [Required]
        public string Content { get; set; }

        [Required]
        public int CourseId { get; set; }
    }
}
