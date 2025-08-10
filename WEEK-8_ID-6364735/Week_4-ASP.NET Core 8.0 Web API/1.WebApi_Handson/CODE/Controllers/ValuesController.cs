using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace CODE.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ValuesController : ControllerBase
    {
        private static List<string> values = new List<string> { "value1", "value2" };

        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            return values;
        }

        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            if (id < 0 || id >= values.Count)
                return NotFound("ID not found.");
            return values[id];
        }

        [HttpPost]
        public ActionResult Post([FromBody] string value)
        {
            if (string.IsNullOrWhiteSpace(value))
                return BadRequest("Value cannot be empty.");

            values.Add(value);
            return Ok("Value added.");
        }

        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] string value)
        {
            if (id < 0 || id >= values.Count)
                return NotFound("ID not found.");
            if (string.IsNullOrWhiteSpace(value))
                return BadRequest("Value cannot be empty.");

            values[id] = value;
            return Ok("Value updated.");
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            if (id < 0 || id >= values.Count)
                return NotFound("ID not found.");

            values.RemoveAt(id);
            return Ok("Value deleted.");
        }
    }
}
