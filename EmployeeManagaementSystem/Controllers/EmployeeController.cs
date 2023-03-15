using Azure;
using EmployeeManagaementSystem.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeManagaementSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly EmsContext _context;

        public EmployeeController(EmsContext context)
        {
            _context = context;
        }

        [HttpGet]
        public ActionResult<List<Employee>> Get()
        {
            return Ok(_context.Employees.ToList());
        }

        [HttpGet("{id}")]
        public ActionResult<Employee> GetbyId(int id)
        {
            if (id == 0)
            {
                return BadRequest();
            }
            var employee = _context.Employees.FirstOrDefault(x => x.Id == id);
            if (employee == null)
            {
                return NotFound();
            }
            return Ok(employee);
        }

        [HttpPost]
        public ActionResult<Employee> AddNew(Employee employee)
        {
            _context.Employees.Add(employee);
            _context.SaveChanges();

            return Ok(employee);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            if (id == 0)
            {
                return BadRequest();
            }
            var employee = _context.Employees.FirstOrDefault(x => x.Id == id);
            if (employee == null)
            {
                return NotFound();
            }
            _context.Employees.Remove(employee);
            _context.SaveChanges();
            return NoContent();
        }
        [HttpPut("{id}")]
        public IActionResult Update(int id, Employee employee)
        {
            var updateEmp = _context.Employees.FirstOrDefault(y => y.Id == id);
            if (updateEmp == null || id == 0)
            {
                return NotFound();
            }
            else
            {
                updateEmp.Name = employee.Name;
                updateEmp.Salary = employee.Salary;
                updateEmp.DateOfJoining = employee.DateOfJoining;
               
            }
            
            _context.Employees.Update(updateEmp);
            _context.SaveChanges();

            return NoContent();

        }

        //[HttpPatch("{id}")]
        //public IActionResult Patch(int id, JsonPatchDocument<Employee> patch)
        //{
          
        //}


    }
}
