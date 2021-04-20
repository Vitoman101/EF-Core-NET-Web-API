using System;
using System.Collections.Generic;

namespace WebAPI.Models
{
    public partial class Course
    {
        public Course()
        {
            StudentCourses = new HashSet<StudentCourses>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Subject { get; set; }
        public int IdTeacher { get; set; }

        public virtual Teacher IdTeacherNavigation { get; set; }
        public virtual ICollection<StudentCourses> StudentCourses { get; set; }
    }
}
