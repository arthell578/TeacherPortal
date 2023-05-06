using Microsoft.EntityFrameworkCore;
using TeacherPortal.Entities;

namespace TeacherPortal.Models
{
    public class TeacherPortalDbContext : DbContext
    {
        public TeacherPortalDbContext(DbContextOptions<TeacherPortalDbContext> options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Lesson> Lessons { get; set; }
    }
}
