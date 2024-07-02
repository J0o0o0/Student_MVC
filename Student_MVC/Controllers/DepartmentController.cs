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
    public class DepartmentController : ControllerBase
    {
        
        private readonly IDepartmentRepository departmentRepository;

        public DepartmentController(IDepartmentRepository departmentRepository)
        {
           
            this.departmentRepository = departmentRepository;
        }

        // GET: api/Department
        [HttpGet]
        public IActionResult GetDepartments()
        {
          if (departmentRepository.GetAll() == null)
          {
              return NotFound();
          }
            return Ok(departmentRepository.GetAll());
        }

        // GET: api/Department/5
        [HttpGet("{id}")]
        public IActionResult GetDepartment(int id)
        {
          if (departmentRepository.GetAll() == null)
          {
              return NotFound();
          }
            var department = departmentRepository.GetDept(id);

            if (department == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(department);

            }

        }

        // PUT: api/Department/5
       
        [HttpPut("{id}")]
        public IActionResult PutDepartment(int id, Department department)
        {
            if (id != department.Id)
            {
                return BadRequest();
            }

            departmentRepository.UpdateDept(id, department);


            return NoContent();
        }

        // POST: api/Department
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public IActionResult PostDepartment(Department department)
        {
          if (departmentRepository.GetAll()  == null)
          {
              return Problem("Entity set 'StdContext.Departments'  is null.");
          }
            departmentRepository.InsertDept(department);
            
            return CreatedAtAction("GetDepartment", new { id = department.Id }, department);
        }

        // DELETE: api/Department/5
        [HttpDelete("{id}")]
        public IActionResult DeleteDepartment(int id)
        {
            if (departmentRepository.GetAll() == null)
            {
                return NotFound();
            }
            var department = departmentRepository.GetDept(id);
            if (department == null)
            {
                return NotFound();
            }

            departmentRepository.DeleteDept(department.Id);
            

            return NoContent();
        }

       
    }
}
