using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using TeacherPortal.Interfaces;
using TeacherPortal.Models;

namespace TeacherPortal.Controllers
{
    [ApiController]
    [Route("/api/account")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost("/register")]
        public ActionResult Register([FromBody] RegisterUserDTO registerUserDTO)
        {
            _userService.Register(registerUserDTO);
            return Ok();
        }

        [HttpPost("/login")]
        public ActionResult Login([FromBody] LoginUserDTO loginUserDTO)
        {
            string token = _userService.GenerateJwtToken(loginUserDTO);

            return Ok(token);
        }
    }
}
