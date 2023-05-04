using System.ComponentModel.DataAnnotations;

namespace TeacherPortal.Models
{
    public class UpdateLessonDTO
    {
        [MaxLength(100)]
        public string Title { get; set; }
        public string Content { get; set; }
    }
}
