using System;
using System.Collections.Generic;

namespace ConsoleApp_EF_DbFirstApproach.Models
{
    public partial class Course
    {
        public Course()
        {
            StudentCourses = new HashSet<StudentCourse>();
        }

        public int CourseId { get; set; }
        public string CourseName { get; set; } = null!;
        public string Description { get; set; } = null!;

        public virtual ICollection<StudentCourse> StudentCourses { get; set; }
    }
}
