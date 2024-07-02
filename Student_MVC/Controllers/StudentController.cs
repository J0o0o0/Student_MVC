using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Student_MVC.Models;
using Student_MVC.Services;

namespace Student_MVC.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        
        private readonly IStudentRepository studentRepository;

        public StudentController(IStudentRepository studentRepository)
        {
            
            this.studentRepository = studentRepository;
        }

        // GET: api/StudentControllerApi
        [HttpGet]
        public  IActionResult GetStudents()
        {
            
          if (studentRepository.GetAll() == null)
          {
              return NotFound();
          }
            return Ok(studentRepository.GetAll());
        }

        // GET: api/StudentControllerApi/5
        [HttpGet("{id:int}")]
        public IActionResult GetStudent(int id)
        {
          if (studentRepository.GetAll() == null)
          {
              return NotFound();
          }
            var student = studentRepository.GetStd(id);

            if (student == null)
            {
                return NotFound();
            }

            return Ok (student);
        }

        // PUT: api/StudentControllerApi/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id:int}")]
        public IActionResult PutStudent(int id, Student student)
        {
            if (id != student.Id)
            {
                return BadRequest();
            }

            studentRepository.UpdateStd(id, student);

            return NoContent();
        }

        // POST: api/StudentControllerApi
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public IActionResult PostStudent(Student student)
        {
          if (studentRepository.GetAll() == null)
          {
              return Problem("Entity set 'StdContext.Students'  is null.");
          }

            studentRepository.InsertStd(student);
            

            return CreatedAtAction("GetStudent", new { id = student.Id }, student);
        }

        // DELETE: api/StudentControllerApi/5
        [HttpDelete("{id}")]
        public IActionResult DeleteStudent(int id)
        {
            if (studentRepository.GetAll() == null)
            {
                return NotFound();
            }
            var student = studentRepository.GetStd(id);
            if (student == null)
            {
                return NotFound();
            }

            studentRepository.DeleteStd(student.Id);
            

            return NoContent();
        }

        
    }
}
