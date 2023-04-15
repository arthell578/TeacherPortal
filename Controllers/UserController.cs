using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using TeacherPortal.Models;

namespace TeacherPortal.Controllers
{
    [ApiController]
    [Route("/api/account")]
    public class UserController
    {
        [HttpPost("/register")]
        public ActionResult Register([FromBody] RegisterUserDTO registerUserDTO)
        {
            return Ok(registerUserDTO);
        }
    }
}
