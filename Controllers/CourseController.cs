using Microsoft.AspNetCore.Mvc;
using TeacherPortal.Interfaces;
using TeacherPortal.Models;

namespace TeacherPortal.Controllers
{
    [ApiController]
    [Route("/api/[controller]")]
    public class CourseController : ControllerBase
    {
        private readonly ICourseService _courseService;

        public CourseController(ICourseService courseService)
        {
            _courseService = courseService;
        }

        [HttpPost]
        public async Task<ActionResult<CourseDTO>> CreateCourse([FromBody] CreateCourseDTO courseDTO)
        {
            var course = await _courseService.CreateCourseAsync(courseDTO);
            return CreatedAtAction(nameof(GetCourse), new { id = course.Id }, course);
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<CourseDTO>>> GetAllCourses()
        {
            var courses = await _courseService.GetAllCoursesAsync();
            return Ok(courses);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<CourseDTO>> GetCourse(int id)
        {
            var course = await _courseService.GetCourseByIdAsync(id);

            if (course == null)
            {
                return NotFound();
            }

            return Ok(course);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<CourseDTO>> UpdateCourse(int id, [FromBody] CreateCourseDTO courseDTO)
        {
            var course = await _courseService.UpdateCourseAsync(id, courseDTO);

            if (course == null)
            {
                return NotFound();
            }

            return Ok(course);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCourse(int id)
        {
            await _courseService.DeleteCourseAsync(id);
            return NoContent();
        }
    }
}
