using EF6.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Data.SqlClient;

namespace EF6.Repository
{
    public class StudentRepository
    {
        private readonly UniversityContext _universityContext;

        public StudentRepository(UniversityContext universityContext)
        {
            _universityContext = universityContext;
        }

        public async Task<List<Student>> GetStudents()
        {
            var students = await _universityContext.Students.ToListAsync();
            return students;
        }

        public async Task<Student> GetStudentDetails(int id)
        {

            var student = await _universityContext.Students.SingleOrDefaultAsync(m => m.ID == id);

            return student;
        }

        public async Task<Student> GetStudentWithTracking(int? id)
        {
            var student = await _universityContext.Students.FindAsync(id);
            return student;
        }

        public async Task<double> GetScore(int studentId)
        {
            string query = @"select ((e.Grade * c.Credits)/sum(c.Credits)) as Grade
                                        from Enrollment e
                                        inner join Course c
                                        on e.CourseId = c.CourseId
                                        where studentId= @studentId
                                        group by e.Grade, c.Credits";
            var studentIdParam = new SqlParameter("@studentId", studentId);

            
            var gradeList = await _universityContext.Database.SqlQuery<int>(query, studentIdParam).ToListAsync();

            if (gradeList.Count == 0)
            {
                return 0;
            }

            return gradeList.Average();

        }
    }
}
