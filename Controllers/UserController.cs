using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
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

        [HttpGet("/user/{id}")]
        public  ActionResult<UserDTO> GetUserByID(int id)
        {
            var user = _userService.GetUserByID(id);

            if(user == null)
            {
                return NotFound();
            }

            return Ok(user);
        }


        [HttpGet("/user")]
        public ActionResult<IEnumerable<UserDTO>> GetAllUsers()
        {
            var users = _userService.GetAllUsers();
            return Ok(users);
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

        [HttpPost("/change-password")]
        [Authorize]
        public async Task<IActionResult> ChangePassword([FromBody] ChangePasswordDTO changePasswordDTO)
        {
            var userId = int.Parse(User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier).Value);
            var result = await _userService.ChangePassword(userId, changePasswordDTO);

            if (!result)
            {
                return BadRequest("Failed to change password.");
            }
            
            return Ok();
        }
    }
}
