using Microsoft.AspNetCore.Mvc;
using TeacherPortal.Interfaces;

namespace TeacherPortal.Controllers
{
    [ApiController]
    public class LessonController : ControllerBase
    {
        private readonly ILessonService _lessonService;

        public LessonController(ILessonService lessonService)
        {
            _lessonService = lessonService;
        }
    }
}
