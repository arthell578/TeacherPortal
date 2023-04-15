using Microsoft.AspNetCore.Mvc;

namespace TeacherPortal.Controllers
{
    [ApiController]
    [Route("/api/account")]
    public class UserController
    {
        [HttpPost("/register")]
        public ActionResult Register([FromBody] UserRegisterDTO)
        {

        }
    }
}
