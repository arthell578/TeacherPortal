using TeacherPortal.Models;

namespace TeacherPortal.Interfaces
{
    public interface IUserService
    {
        void Register(RegisterUserDTO registerUserDTO);
        string GenerateJwtToken(LoginUserDTO loginUserDTO);
        Task<bool> ChangePassword(int userId, ChangePasswordDTO changePasswordDTO);
    }
}