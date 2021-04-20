using System;
using System.Collections.Generic;

namespace WebAPI.Models
{
    public partial class StudentCourses
    {
        public int Id { get; set; }
        public int IdStudent { get; set; }
        public int IdCourse { get; set; }

        public virtual Course IdCourseNavigation { get; set; }
        public virtual Student IdStudentNavigation { get; set; }
    }
}
