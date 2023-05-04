using Microsoft.AspNetCore.Mvc;
using TeacherPortal.Interfaces;
using TeacherPortal.Models;

namespace TeacherPortal.Controllers
{
    [ApiController]
    [Route("/api/[controller]")]

    public class LessonController : ControllerBase
    {
        private readonly ILessonService _lessonService;

        public LessonController(ILessonService lessonService)
        {
            _lessonService = lessonService;
        }

        [HttpPost]
        public async Task<ActionResult<LessonDTO>> CreateLesson([FromBody] CreateLessonDTO lessonDTO)
        {
            var lesson = await _lessonService.CreateLessonAsync(lessonDTO);
            return CreatedAtAction(nameof(GetLesson), new { id = lesson.Id }, lesson);
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<LessonDTO>>> GetAllLessons()
        {
            var lessons = await _lessonService.GetAllLessonsAsync();
            return Ok(lessons);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<LessonDTO>> GetLesson(int id)
        {
            var lesson = await _lessonService.GetLessonByIdAsync(id);

            if (lesson == null)
            {
                return NotFound();
            }

            return Ok(lesson);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<LessonDTO>> UpdateLesson(int id, [FromBody] UpdateLessonDTO lessonDTO)
        {
            var lesson = await _lessonService.UpdateLessonAsync(id, lessonDTO);

            if (lesson == null)
            {
                return NotFound();
            }

            return Ok(lesson);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteLesson(int id)
        {
            await _lessonService.DeleteLessonAsync(id);
            return NoContent();
        }
    }
}
