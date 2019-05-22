using EF6.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SampleWithEF6.Models
{
    public class StudentDetails : Student
    {
        public double Score { get; set; }

        public StudentDetails(Student student, double score)
        {
            Enrollment = student.Enrollment;
            EnrollmentDate = student.EnrollmentDate;
            FirstMidName = student.FirstMidName;
            ID = student.ID;
            LastName = student.LastName;
            Score = score;
        }

    }
}
