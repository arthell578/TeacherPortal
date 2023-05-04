namespace TeacherPortal.Models
{
    public class LessonDTO
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public int CourseId { get; set; }
    }
}
