namespace TeacherPortal.Models
{
    public class RegisterUserDTO
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public UserRole UserRole { get; set; } = UserRole.Student;
    }
}
