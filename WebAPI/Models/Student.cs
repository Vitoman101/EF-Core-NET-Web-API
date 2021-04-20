using System;
using System.Collections.Generic;

namespace WebAPI.Models
{
    public partial class Student
    {
        public Student()
        {
            StudentCourses = new HashSet<StudentCourses>();
        }

        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }

        public virtual ICollection<StudentCourses> StudentCourses { get; set; }
    }
}
