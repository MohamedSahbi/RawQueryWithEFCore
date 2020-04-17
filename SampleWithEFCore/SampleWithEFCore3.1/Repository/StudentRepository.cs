using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using SampleWithEFCore.DAL.Models;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Threading.Tasks;

namespace SampleWithEFCore3._1.Repository
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
            var students = await _universityContext.Student.ToListAsync();
            return students;
        }

        public async Task<List<Enrollment>> GetEnrollments()
        {
            var result = await _universityContext.Enrollment.ToListAsync();
            return result;
        }

        // recommended implementation
        public async Task<double> GetScore(int studentId)
        {

            string query = @"select ((e.Grade * c.Credits)/sum(c.Credits)) as Grade
                                        from Enrollment e
                                        inner join Course c
                                        on e.CourseId = c.CourseId
                                        where studentId= @studentId
                                        group by e.Grade, c.Credits";
            var idParam = new SqlParameter("@studentId", studentId);
            var gradeList = await _universityContext.Set<AverageGrade>().FromSqlRaw(query, idParam).ToListAsync();

            return gradeList.Select(x => x.Grade).ToList().Average();

        }


        // Not recommended
        public async Task<double> GetScoreAdoNet(int studentId)
        {
            string queryString = @"select ((e.Grade * c.Credits)/sum(c.Credits)) as Grade
                                        from Enrollment e
                                        inner join Course c
                                        on e.CourseId = c.CourseId
                                        where studentId= @studentId
                                        group by e.Grade, c.Credits";

            var gradeList = new List<int>();

            var conn = _universityContext.Database.GetDbConnection();
            try
            {
                await conn.OpenAsync();

                using (var command = conn.CreateCommand())
                {
                    // Create the Command and Parameter objects.
                    command.CommandText = queryString;
                    var parameter = command.CreateParameter();
                    parameter.ParameterName = "@studentId";
                    parameter.Value = studentId;
                    command.Parameters.Add(parameter);

                    DbDataReader reader = await command.ExecuteReaderAsync();
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            gradeList.Add(reader.GetInt32(0));
                        }
                    }
                    reader.Dispose();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                conn.Close();
            }

            return gradeList.ToList().Average();
        }


    }
}
