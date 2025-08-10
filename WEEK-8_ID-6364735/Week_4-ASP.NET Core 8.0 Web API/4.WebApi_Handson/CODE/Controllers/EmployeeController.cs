using Microsoft.AspNetCore.Mvc;
using CODE.Models;
using System.Collections.Generic;
using System.Linq;

namespace CODE.Controllers
{
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

        // GET all employees
        [HttpGet]
        [ProducesResponseType(typeof(List<Employee>), StatusCodes.Status200OK)]
        public ActionResult<List<Employee>> Get()
        {
            return Ok(employees);
        }

        // GET employee by ID
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(Employee), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<Employee> GetEmployeeById(int id)
        {
            var employee = employees.FirstOrDefault(e => e.Id == id);
            if (employee == null)
            {
                return NotFound($"Employee with ID {id} not found.");
            }
            return Ok(employee);
        }

        // PUT: update employee
        [HttpPut("{id}")]
        [ProducesResponseType(typeof(Employee), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<Employee> UpdateEmployee(int id, [FromBody] Employee updatedEmp)
        {
            // ✅ Step 1: Check if ID is valid number
            if (id <= 0)
                return BadRequest("Invalid employee id");

            // ✅ Step 2: Check if URL ID and Body ID match
            if (id != updatedEmp.Id)
                return BadRequest("Employee ID in URL must match ID in request body");

            // ✅ Step 3: Check if employee exists
            var emp = employees.FirstOrDefault(e => e.Id == id);
            if (emp == null)
                return BadRequest("Invalid employee id");

            // ✅ Step 4: Update employee
            emp.Name = updatedEmp.Name;
            emp.Salary = updatedEmp.Salary;

            return Ok(emp);
        }
    }
}
