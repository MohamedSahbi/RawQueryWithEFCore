using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EF6;
using EF6.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Data.Entity;
using SampleWithEF6.Models;

namespace SampleWithEF6.Controllers
{

    public class StudentsController : Controller
    {
        private readonly StudentRepository _studentRepository;
        public StudentsController(UniversityContext context)
        {
            _studentRepository = new StudentRepository(context);
        }

        public async Task<IActionResult> Index()
        {

            return View(await _studentRepository.GetStudents());
        }

        // GET: Students/Details/5
        public async Task<IActionResult> Details(int? id)
        {

            if (id == null)
            {
                return NotFound();
            }
            int studentId = id ?? 0;
            var student = await _studentRepository.GetStudentDetails(studentId);
            var score = await _studentRepository.GetScore(studentId);

            if (student == null)
            {
                return NotFound();
            }

            var studentDetails = new StudentDetails(student,score);
            return View(studentDetails);
        }

        // GET: Students/Create
        public IActionResult Create()
        {
            return View();
        }

        // GET: Students/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var student = await _studentRepository.GetStudentWithTracking(id);

            if (student == null)
            {
                return NotFound();
            }
            return View(student);
        }
    }
}