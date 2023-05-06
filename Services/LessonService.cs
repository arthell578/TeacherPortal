using AutoMapper;
using Microsoft.EntityFrameworkCore;
using TeacherPortal.Entities;
using TeacherPortal.Interfaces;
using TeacherPortal.Models;

namespace TeacherPortal.Services
{
    public class LessonService : ILessonService
    {
        private readonly TeacherPortalDbContext _context;
        private readonly IMapper _mapper;

        public LessonService(TeacherPortalDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<LessonDTO> CreateLessonAsync(CreateLessonDTO lessonDTO)
        {
            var lesson = _mapper.Map<Lesson>(lessonDTO);
            _context.Lessons.Add(lesson);
            await _context.SaveChangesAsync();

            return _mapper.Map<LessonDTO>(lesson);
        }

        public async Task<IEnumerable<LessonDTO>> GetAllLessonsAsync()
        {
            var lessons = await _context.Lessons.ToListAsync();
            return _mapper.Map<IEnumerable<LessonDTO>>(lessons);
        }

        public async Task<LessonDTO> GetLessonByIdAsync(int id)
        {
            var lesson = await _context.Lessons.FindAsync(id);
            return _mapper.Map<LessonDTO>(lesson);
        }

        public async Task<LessonDTO> UpdateLessonAsync(int id, UpdateLessonDTO lessonDTO)
        {
            var lesson = await _context.Lessons.FindAsync(id);
            _mapper.Map(lessonDTO, lesson);
            await _context.SaveChangesAsync();

            return _mapper.Map<LessonDTO>(lesson);
        }

        public async Task DeleteLessonAsync(int id)
        {
            var lesson = await _context.Lessons.FindAsync(id);
            _context.Lessons.Remove(lesson);
            await _context.SaveChangesAsync();
        }
    }
}
