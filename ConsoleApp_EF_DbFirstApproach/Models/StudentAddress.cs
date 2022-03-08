using System;
using System.Collections.Generic;

namespace ConsoleApp_EF_DbFirstApproach.Models
{
    public partial class StudentAddress
    {
        public StudentAddress()
        {
            Students = new HashSet<Student>();
        }

        public int StudentAddressId { get; set; }
        public string Address { get; set; } = null!;
        public string City { get; set; } = null!;
        public string State { get; set; } = null!;
        public string Country { get; set; } = null!;

        public virtual ICollection<Student> Students { get; set; }
    }
}
