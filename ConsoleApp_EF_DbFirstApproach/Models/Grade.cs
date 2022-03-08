using System;
using System.Collections.Generic;

namespace ConsoleApp_EF_DbFirstApproach.Models
{
    public partial class Grade
    {
        public Grade()
        {
            Students = new HashSet<Student>();
        }

        public int GradeId { get; set; }
        public string GradeName { get; set; } = null!;
        public string Section { get; set; } = null!;

        public virtual ICollection<Student> Students { get; set; }
    }
}
