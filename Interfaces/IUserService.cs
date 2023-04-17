using TeacherPortal.Models;

namespace TeacherPortal.Interfaces
{
    public interface IUserService
    {
        void Register(RegisterUserDTO registerUserDTO);
    }
}