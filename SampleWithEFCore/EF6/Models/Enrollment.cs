﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF6.Models
{
    public enum Grade
    {
        A = 1,
        B = 2,
        C = 3,
        D = 4,
        F = 5
    }

    public class Enrollment
    {
        public int EnrollmentID { get; set; }
        public int CourseID { get; set; }
        public int StudentID { get; set; }
        public Grade? Grade { get; set; }

        public  Course Course { get; set; }
        public  Student Student { get; set; }
    }
}
