using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace RESTfulAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Employees2Controller : ControllerBase
    {
        private static List<Model.Employees2> _employees = new List<Model.Employees2>(new[]
        {
                new Model.Employees2() { ID = 1, Name = "Peter", Division = "sales", Rank = "salesmanager"},
                new Model.Employees2() { ID = 2, Name = "Paul", Division = "sales", Rank = "salesmanager assistant"},
                new Model.Employees2() { ID = 3, Name = "Joseph", Division = "sales", Rank = "salesman"},
                new Model.Employees2() { ID = 4, Name = "Erik", Division = "sales", Rank = "salesman"},
                new Model.Employees2() { ID = 5, Name = "Mark", Division = "sales", Rank = "salesman"}
        });
        [HttpGet]
        public List<Model.Employees2> Get()
        {
            return _employees; //pretend to go to the database            
        }

        [HttpGet("{id}")] //capture route parameter
        public Microsoft.AspNetCore.Mvc.IActionResult Get(int id)
        {
            var employees = _employees.SingleOrDefault(p => p.ID == id);
            if (employees == null)
            {
                return NotFound();
            }
            return Ok(employees);
        }

        [HttpPost]
        public IActionResult Post([FromBody] Model.Employees2 employees)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            _employees.Add(employees);
            return CreatedAtAction(nameof(Get),
                new { id = employees.ID }, employees);
        }
    }
}