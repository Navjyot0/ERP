using ConsoleApp_EF_DbFirstApproach.Models;
using Microsoft.EntityFrameworkCore;

namespace ConsoleApp_EF_DbFirstApproach
{
    internal class SchoolCRUD : IDisposable
    {
        public SchoolCRUD()//(Employee_DbFirstApproachContext db)
        {
            Db = new Employee_DbFirstApproachContext(new Microsoft.EntityFrameworkCore.DbContextOptions<Employee_DbFirstApproachContext>());
        }

        public Employee_DbFirstApproachContext Db { get; }

        private static Student student = new Student()
        {
            Name = "srgrgre greg erg",
            Grade = new Grade() { GradeName = "B", Section = "fwefewf"},
            StudentAddress = new StudentAddress() { City = "wefwefwef", State = "efwef", Country = "wefwefef", Address = "wefwefef" }
        };

        private static Course course = new Course() { CourseName = "fsdfsdfsdf", Description = "sdfsdfsdf" };

        private static StudentCourse studentCourse = new StudentCourse()
        {
            Student = student,
            Course = course
        };

        public void AddNewStudents()
        {
            Db.StudentCourses.Add(studentCourse);
            Db.SaveChanges();
        }

        public void GetStudents()
        {
            //Be sure you are using Include from Microsoft.EntityFrameworkCore And Not from System.Data.Entity
            var students = Db.Students.Include(x => x.Grade).Include(x=>x.StudentAddress).Include(x=>x.StudentCourses).ThenInclude(x=>x.Course).ToList();
        }

        public void DeleteStudent()
        {
            var students = Db.Students.Remove(Db.Students.FirstOrDefault(s => s.Id == 2));
            Db.SaveChanges();
        }

        public void GetStudentBySqlQuery()
        {
            var studentwithAddress = Db.Students
                .FromSqlRaw("SELECT Id, Name, GradeId, S.StudentAddressId, Address, City, State, Country FROM Student S LEFT JOIN StudentAddresses SA ON S.StudentAddressId = SA.StudentAddressId")
                .Include(x => x.StudentAddress)
                .ToList();
        }

        public void GetStudentByIdFromSqlStoredProcedure(int StudentId)
        {
            var studentwithAddress = Db.Students
                .FromSqlRaw($"EXECUTE dbo.GetStudentsById {StudentId}")
                .Include(x => x.StudentAddress)
                .AsEnumerable();
        }

        public void Dispose()
        {
            ((IDisposable)Db).Dispose();
        }
    }
}
