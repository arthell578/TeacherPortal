using Microsoft.AspNetCore.Identity;
using TeacherPortal.Models;

namespace TeacherPortal.Interfaces
{
    public class UserService : IUserService
    {
        private readonly TeacherPortalDbContext _dbContext;
        private readonly IPasswordHasher<User> _passwordHasher;

        public UserService(TeacherPortalDbContext dbContext, IPasswordHasher<User> passwordHasher)
        {
            _dbContext = dbContext;
            _passwordHasher = passwordHasher;
        }
        public void Register(RegisterUserDTO registerUserDTO)
        {
            var newUser = new User()
            {
                Email = registerUserDTO.Email,
                UserRole = registerUserDTO.UserRole,
                FirstName= registerUserDTO.FirstName,
                LastName= registerUserDTO.LastName,
                Password= registerUserDTO.Password
            };

            _dbContext.Users.Add(newUser);
            _dbContext.SaveChanges();
        }
    }
}
