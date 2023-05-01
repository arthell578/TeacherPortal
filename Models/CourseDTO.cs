﻿namespace TeacherPortal.Models
{
    public class CourseDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public ICollection<LessonDTO> Lessons { get; set; }
    }
}
