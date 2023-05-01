using Microsoft.AspNetCore.Mvc;
using TeacherPortal.Interfaces;

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
    }
}
