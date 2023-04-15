﻿using Microsoft.EntityFrameworkCore;

namespace TeacherPortal.Models
{
    public class TeacherPortalDbContext : DbContext
    {
        protected TeacherPortalDbContext(DbContextOptions<TeacherPortalDbContext> options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Lesson> Lessons { get; set; }
    }
}