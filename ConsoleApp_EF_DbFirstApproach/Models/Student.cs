using System;
using System.Collections.Generic;

namespace ConsoleApp_EF_DbFirstApproach.Models
{
    public partial class Student
    {
        public Student()
        {
            StudentCourses = new HashSet<StudentCourse>();
        }

        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public int GradeId { get; set; }
        public int StudentAddressId { get; set; }

        public virtual Grade Grade { get; set; } = null!;
        public virtual StudentAddress StudentAddress { get; set; } = null!;
        public virtual ICollection<StudentCourse> StudentCourses { get; set; }
    }
}
