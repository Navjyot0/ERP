using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace Students.WebAPI.Models
{
    public class Class
    {
    }
    //public class Student
    //{
    //    public int Id { get; set; }
    //    public string Name { get; set; }

    //    [NotMapped]
    //    public int CurrentGradeId { get; set; }

    //    [NotMapped]
    //    public Grade Grade { get; set; } //One to many

    //    [NotMapped]
    //    public StudentAddress Address { get; set; } // One to one

    //    [NotMapped]
    //    public IList<StudentCourse> StudentCourses { get; set; } //Many to Many
    //}
    //public class Grade
    //{
    //    public int GradeId { get; set; }
    //    public string GradeName { get; set; }
    //    public string Section { get; set; }

    //    [NotMapped]
    //    public ICollection<Student> Students { get; set; }//One to many
    //}
    //public class StudentAddress
    //{
    //    public int StudentAddressId { get; set; }
    //    public string Address { get; set; }
    //    public string City { get; set; }
    //    public string State { get; set; }
    //    public string Country { get; set; }

    //    [NotMapped]
    //    public int AddressOfStudentId { get; set; }
    //    [NotMapped]
    //    public Student Student { get; set; } // One to one
    //}
    //public class Course
    //{
    //    public int CourseId { get; set; }
    //    public string CourseName { get; set; }
    //    public string Description { get; set; }

    //    [NotMapped]
    //    public IList<StudentCourse> StudentCourses { get; set; }//Many to Many
    //}
    //public class StudentCourse//Many to Many
    //{
    //    [NotMapped]
    //    public int StudentId { get; set; }
    //    [NotMapped]
    //    public Student Student { get; set; } //Many to Many

    //    [NotMapped]
    //    public int CourseId { get; set; }
    //    [NotMapped]
    //    public Course Course { get; set; } //Many to Many
    //}

    public class Student
    {
        public int Id { get; set; }

        public string Name { get; set; }

        [JsonIgnore]
        public int GradeId { get; set; }

        public virtual Grade Grade { get; set; } //One to many

        [JsonIgnore]
        public  int StudentAddressId { get; set; }
        
        public virtual StudentAddress Address { get; set; } // One to one
    }

    public class Grade
    {
        public int GradeId { get; set; }
        public string GradeName { get; set; }
        public string Section { get; set; }
    }

    public class StudentAddress
    {
        public int StudentAddressId { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
    }

    public class Course
    {
        public int CourseId { get; set; }
        public string CourseName { get; set; }
        public string Description { get; set; }
    }

    public class StudentCourse//Many to Many
    {
        public int StudentCourseId { get; set; }
        public int StudentId { get; set; }
        public virtual Student Student { get; set; } //Many to Many
        public int CourseId { get; set; }
        public virtual Course Course { get; set; } //Many to Many
    }
}
