using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using EmployeeManager.Domain.Models;

namespace EmployeeManager.Api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        // GET employee
        [HttpGet]
        public ActionResult<Employees> Get()
        {
            return new Employees {
                new Employee {
                    name = "Arnaldo Pereira",
                    email = "arnaldo@luizalabs.com",
                    department = "Architecture"
                },
                new Employee {
                    name = "Arnaldo Pereira",
                    email = "arnaldo@luizalabs.com",
                    department = "Architecture"
                },
                new Employee {
                    name = "Arnaldo Pereira",
                    email = "arnaldo@luizalabs.com",
                    department = "Architecture"
                },
            };
        }

        // GET employee/5
        [HttpGet("{id}")]
        public ActionResult<Employee> Get(int id)
        {
            return new Employee
            {
                name = "Arnaldo Pereira",
                email = "arnaldo@luizalabs.com",
                department = "Architecture"
            };
        }

        // POST employee
        [HttpPost]
        public void Post([FromBody] Employee value)
        {

        }

        // PUT employee/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {

        }

        // DELETE employee/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            
        }
    }
}