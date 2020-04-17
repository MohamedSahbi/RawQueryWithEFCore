using Microsoft.AspNetCore.Mvc;
using SampleWithEFCore.DAL.Models;
using SampleWithEFCore3._1.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SampleWithEFCore3._1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : Controller
    {
        private readonly StudentRepository _studentRepository;

        public StudentsController(UniversityContext schoolContext)
        {
            _studentRepository = new StudentRepository(schoolContext);
        }

        [HttpGet("GetAllStudents")]
        public async Task<JsonResult> GetStudents()
        {
            var students = await _studentRepository.GetStudents();
            return Json(students);
        }

        /// <summary>
        /// Get score of student
        /// </summary>
        /// <remarks>
        /// This endpoint is using EF Core - QueryTypes
        /// </remarks>
        /// <param name="studentId"></param>
        /// <returns>score</returns>
        [HttpGet("GetScore")]
        public async Task<double> GetScore(int studentId)
        {
            var score = await _studentRepository.GetScore(studentId);
            return score;
        }

        /// <summary>
        /// Get score of student
        /// </summary>
        /// <remarks>
        /// This endpoint is using the implementation of ADO.NET, it is not recommended
        /// </remarks>
        /// <param name="studentId"></param>
        /// <returns>score</returns>
        [HttpGet("GetScoreAdoDotNet")]
        public async Task<double> GetScoreAdoDotNet(int studentId)
        {
            var score = await _studentRepository.GetScoreAdoNet(studentId);
            return score;
        }

        [HttpGet("GetEnrollments")]
        public async Task<List<Enrollment>> GetEnrollments()
        {
            return await _studentRepository.GetEnrollments();
        }
    }
}