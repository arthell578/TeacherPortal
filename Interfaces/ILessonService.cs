using TeacherPortal.Models;

namespace TeacherPortal.Interfaces
{
    public interface ILessonService
    {
        Task<LessonDTO> CreateLessonAsync(CreateLessonDTO lessonDTO);
        Task<IEnumerable<LessonDTO>> GetAllLessonsAsync();
        Task<LessonDTO> GetLessonByIdAsync(int id);
        Task<LessonDTO> UpdateLessonAsync(int id, UpdateLessonDTO lessonDTO);
        Task DeleteLessonAsync(int id);
    }
}
