using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using EmployeeManager.Domain.Models;
using EmployeeManager.Infrastructure.Repositories;

namespace EmployeeManager.Api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeRepository _repository;
        public EmployeeController(IEmployeeRepository repository)
        {
            _repository = repository;
        }

        // GET employee
        [HttpGet]
        public async Task<ActionResult<List<Employee>>> Get()
        {
            return await _repository.GetAllAsync();
        }

        // GET employee/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            if (id > 0)
            {
                var employee = await _repository.GetAsync(id);
                if (employee == null)
                {
                    return NotFound();
                }

                return Ok(employee);
            }

            return BadRequest();
        }

        // POST employee
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Employee employee)
        {
            if (ModelState.IsValid)
            {
                employee.Id = 0;
                var employeeId = await _repository.AddAsync(employee);

                return Ok(employeeId);
            }

            return BadRequest(ModelState);
        }

        // PUT employee/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] Employee employee)
        {
            if (id <= 0)
                return BadRequest();

            if (ModelState.IsValid)
            {
                try
                {
                    employee.Id = id;
                    await _repository.UpdateAsync(employee);

                    return Ok();
                }
                catch (Exception ex)
                {
                    if (ex.GetType().FullName.Equals("Microsoft.EntityFrameworkCore.DbUpdateConcurrencyException"))
                    {
                        return NotFound();
                    }

                    throw ex;
                }
            }

            return BadRequest(ModelState);
        }

        // DELETE employee/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            if (id > 0)
            {
                var result = await _repository.DeleteAsync(id);
                if (result == 0)
                {
                    return NotFound();
                }

                return Ok();
            }

            return BadRequest();
        }
    }
}