﻿using System.ComponentModel.DataAnnotations;

namespace TeacherPortal.Models
{
    public class RegisterUserDTO
    {
        [Required]
        public string Email { get; set; }
        [Required]
        [MinLength(8)]
        public string Password { get; set; }
        public UserRole UserRole { get; set; } = UserRole.Student;
    }
}