using Humanizer;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SchoolManagementSystem.Models;
using System.Security.Claims;

namespace SchoolManagementSystem.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Student> Students { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Classroom> Classrooms { get; set; }
        
        public DbSet<Section> Sections { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Classroom>().HasData(
                new Classroom { Id = 1, Name = "Class 1", RoomNumber = "101" },
                new Classroom { Id = 2, Name = "Class 2", RoomNumber = "102" }
            );

            modelBuilder.Entity<Section>().HasData(
                new Section { Id = 1, Name = "A", ClassroomId = 1 },
                new Section { Id = 2, Name = "B", ClassroomId = 1 },
                new Section { Id = 3, Name = "A", ClassroomId = 2 },
                new Section { Id = 4, Name = "B", ClassroomId = 2 }
            );
        }

    }
}
}

