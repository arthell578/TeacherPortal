using AutoMapper;
using Microsoft.EntityFrameworkCore;
using TeacherPortal.Interfaces;
using TeacherPortal.Models;

namespace TeacherPortal.Services
{
    public class CourseService : ICourseService
    {
        private readonly TeacherPortalDbContext _dbContext;
        private readonly IMapper _mapper;

        public CourseService(TeacherPortalDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<CourseDTO> CreateCourseAsync(CreateCourseDTO courseDTO)
        {
            var course = _mapper.Map<Course>(courseDTO);
            _dbContext.Courses.Add(course);
            await _dbContext.SaveChangesAsync();

            return _mapper.Map<CourseDTO>(course);
        }

        public async Task<IEnumerable<CourseDTO>> GetAllCoursesAsync()
        {
            var courses = await _dbContext.Courses.ToListAsync();
            return _mapper.Map<IEnumerable<CourseDTO>>(courses);
        }

        public async Task<CourseDTO> GetCourseByIdAsync(int id)
        {
            var course = await _dbContext.Courses.FindAsync(id);
            return _mapper.Map<CourseDTO>(course);
        }

        public async Task<CourseDTO> UpdateCourseAsync(int id, CreateCourseDTO courseDTO)
        {
            var course = await _dbContext.Courses.FindAsync(id);
            _mapper.Map(courseDTO, course);
            await _dbContext.SaveChangesAsync();

            return _mapper.Map<CourseDTO>(course);
        }

        public async Task DeleteCourseAsync(int id)
        {
            var course = await _dbContext.Courses.FindAsync(id);
            _dbContext.Courses.Remove(course);
            await _dbContext.SaveChangesAsync();
        }
    }
}
