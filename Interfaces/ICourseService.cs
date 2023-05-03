using TeacherPortal.Models;

namespace TeacherPortal.Interfaces
{
    public interface ICourseService
    {
        Task<CourseDTO> CreateCourseAsync(CreateCourseDTO courseDTO);
        Task<IEnumerable<CourseDTO>> GetAllCoursesAsync();
        Task<CourseDTO> GetCourseByIdAsync(int id);
        Task<CourseDTO> UpdateCourseAsync(int id, CreateCourseDTO courseDTO);
        Task DeleteCourseAsync(int id);
    }
}
