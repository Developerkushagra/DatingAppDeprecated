using System.Collections.Generic;
using DatingApp.API.Data;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace DatingApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private readonly DataContext _context;
        public ValuesController(DataContext context)
        {
            _context = context;

        }
        List<string> strings = new List<string>() {
            "kush","bhagyashree","shruti"
        };
        [HttpGet]
        public IActionResult Get()
        {
            var values = _context.MyProperty.ToList();
            return Ok(values);
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var value = _context.MyProperty.FirstOrDefault(x => x.Id==id);
            return Ok(value);
        }

        [HttpPost]
        public void Post([FromBody] string value)
        {
            strings.Add(value);
        }

        [HttpPost("{id}")]
        public void Put(int id, [FromBody] string value)
        {
            strings[id] = value;
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            strings.RemoveAt(id);
        }
    }
}
