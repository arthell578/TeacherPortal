﻿using TeacherPortal.Models;

namespace TeacherPortal.Interfaces
{
    public class UserService : IUserService
    {
        private readonly TeacherPortalDbContext _dbContext;

        public UserService(TeacherPortalDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public void Register(RegisterUserDTO registerUserDTO)
        {
            var newUser = new User()
            {
                Email = registerUserDTO.Email,
                UserRole = registerUserDTO.UserRole,
            };

            _dbContext.Users.Add(newUser);
            _dbContext.SaveChanges();
        }
    }
}