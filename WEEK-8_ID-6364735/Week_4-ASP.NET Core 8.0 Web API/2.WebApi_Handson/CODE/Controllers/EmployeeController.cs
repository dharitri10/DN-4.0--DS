using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace CODE.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EmployeeController : ControllerBase
    {
        private static List<string> employees = new List<string>
        {
            "Moinak", "Alex", "John"
        };

        [HttpGet]
        public ActionResult<IEnumerable<string>> GetEmployees()
        {
            return employees;
        }
    }
}
