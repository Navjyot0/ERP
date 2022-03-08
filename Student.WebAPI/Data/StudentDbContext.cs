using Students.WebAPI.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Students.WebAPI.Data
{
    public class StudentDbContext : DbContext //IdentityDbContext
    {
        public StudentDbContext(DbContextOptions<StudentDbContext> options) : base(options)
        {
        }

        //public DbSet<Students.WebAPI.Models.Employee> Employees { get; set; }
        public DbSet<Students.WebAPI.Models.Student> Students { get; set; }
        public DbSet<Students.WebAPI.Models.Grade> Grades { get; set; }
        public DbSet<Students.WebAPI.Models.StudentAddress> StudentAddresses { get; set; }
        public DbSet<Students.WebAPI.Models.Course> Courses { get; set; }
        public DbSet<Students.WebAPI.Models.StudentCourse> StudentCourses { get; set; }


        protected override void OnModelCreating(ModelBuilder builder)
        {
            //builder.Entity<Students.WebAPI.Models.Employee>().HasData(new Models.Employee { EmployeeId= 1, FirstName = "Navjyot", LastName = "Gurhale", Age = 28 });

            ////With Fluent API
            ////One to One(Student->StudentAddress)
            //builder.Entity<Student>()
            //    .HasOne<StudentAddress>(s => s.Address)
            //    .WithOne(ad => ad.Student)
            //    .HasForeignKey<StudentAddress>(ad => ad.AddressOfStudentId);

            ////One to Many(Student -> Grades)
            //builder.Entity<Student>()
            //    .HasOne<Grade>(s => s.Grade)
            //    .WithMany(g => g.Students)
            //    .HasForeignKey(s => s.CurrentGradeId);

            ////Many to Many(Courses <-> Students)
            //builder.Entity<StudentCourse>().HasKey(sc => new { sc.StudentId, sc.CourseId });
            //builder.Entity<StudentCourse>()
            //    .HasOne<Student>(sc => sc.Student)
            //    .WithMany(s => s.StudentCourses)
            //    .HasForeignKey(sc => sc.StudentId);
            //builder.Entity<StudentCourse>()
            //    .HasOne<Course>(sc => sc.Course)
            //    .WithMany(s => s.StudentCourses)
            //    .HasForeignKey(sc => sc.CourseId);
            ////builder.Seed();


            base.OnModelCreating(builder);
        }
    }
}
