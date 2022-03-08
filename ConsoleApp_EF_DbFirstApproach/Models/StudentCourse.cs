﻿using System;
using System.Collections.Generic;

namespace ConsoleApp_EF_DbFirstApproach.Models
{
    public partial class StudentCourse
    {
        public int StudentCourseId { get; set; }
        public int StudentId { get; set; }
        public int CourseId { get; set; }

        public virtual Course Course { get; set; } = null!;
        public virtual Student Student { get; set; } = null!;
    }
}
