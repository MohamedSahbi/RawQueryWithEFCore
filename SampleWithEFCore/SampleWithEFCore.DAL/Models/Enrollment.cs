using System;
using System.Collections.Generic;
using System.Text;

namespace SampleWithEFCore.DAL.Models
{
    public enum Grade
    {
        A = 1,
        B = 2,
        C = 3,
        D = 4,
        F = 5
    }


    public partial class Enrollment
    {
        public int EnrollmentId { get; set; }
        public int CourseId { get; set; }
        public int StudentId { get; set; }
        public int Grade { get; set; }

        public Course Course { get; set; }
        public Student Student { get; set; }
    }
}
