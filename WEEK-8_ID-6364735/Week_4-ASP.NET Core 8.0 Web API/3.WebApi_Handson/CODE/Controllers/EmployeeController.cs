using Microsoft.AspNetCore.Mvc;
using CODE.Models;
using CODE.Filters;
using System;
using System.Collections.Generic;

namespace CODE.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [CustomAuthFilter]
    public class EmployeeController : ControllerBase
    {
        [HttpGet]
        [ProducesResponseType(typeof(List<Employee>), 200)]
        [ProducesResponseType(500)]
        public ActionResult<List<Employee>> Get()
        {
            throw new Exception("Intentional exception to test filter");
            // return GetStandardEmployeeList();
        }

        [HttpGet("standard")]
        public ActionResult<Employee> GetStandard()
        {
            return GetStandardEmployeeList()[0];
        }

        [HttpPost]
        public IActionResult Post([FromBody] Employee emp)
        {
            return Ok("Employee added.");
        }

        private List<Employee> GetStandardEmployeeList()
        {
            return new List<Employee>
            {
                new Employee
                {
                    Id = 1,
                    Name = "Moinak",
                    Salary = 50000,
                    Permanent = true,
                    Department = new Department { Id = 101, DeptName = "IT" },
                    Skills = new List<Skill>
                    {
                        new Skill { Id = 1, SkillName = "C#" },
                        new Skill { Id = 2, SkillName = "SQL" }
                    },
                    DateOfBirth = new DateTime(1998, 1, 1)
                }
            };
        }
    }
}
