using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using CODE.Models;
using System.Collections.Generic;
using System.Linq;

namespace CODE.Controllers
{
    [Authorize(Roles = "Admin,POC")]
    [ApiController]
    [Route("api/[controller]")]
    public class EmployeeController : ControllerBase
    {
        private static List<Employee> employees = new List<Employee>
        {
            new Employee { Id = 1, Name = "Moinak", Salary = 50000 },
            new Employee { Id = 2, Name = "John", Salary = 60000 },
            new Employee { Id = 3, Name = "Alice", Salary = 70000 }
        };

        [HttpGet]
        public ActionResult<List<Employee>> GetAll()
        {
            return Ok(employees);
        }

        [HttpPut("{id}")]
        public ActionResult<Employee> UpdateEmployee(int id, [FromBody] Employee updatedEmp)
        {
            if (id <= 0 || id != updatedEmp.Id)
                return BadRequest("Employee ID in URL must match ID in request body");

            var emp = employees.FirstOrDefault(e => e.Id == id);
            if (emp == null)
                return BadRequest("Invalid employee id");

            emp.Name = updatedEmp.Name;
            emp.Salary = updatedEmp.Salary;
            return Ok(emp);
        }
    }
}
