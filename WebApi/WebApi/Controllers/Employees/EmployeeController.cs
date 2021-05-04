using Application.Common.Exceptions;
using Application.Employees.Commands.Create;
using Application.Employees.Commands.Delete;
using Application.Employees.Commands.Read;
using Application.Repositories.Interfaces;
using Domain.Employees;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Net;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApi.Controllers.Employees
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly CreateEmployee create;
        private readonly DeleteEmployee delete;
        private readonly ReadEmployee read;

        public EmployeeController(Startup.DeleteByNameResolver deleteAccesor, IEmployeeReadOnlyRepository read, ICreate<Employee> create)
        {
            delete = new DeleteEmployee(deleteAccesor(DeletesEmail.Client), read);
            this.create = new CreateEmployee(create, read);
            this.read = new ReadEmployee(read);
        }

        // GET: api/Employee
        [HttpGet]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(ApiResponse<IEnumerable<Employee>>))]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public IActionResult Get()
        {
            return Ok(new ApiResponse<IEnumerable<Employee>>(read.All));
        }

        // POST api/Employee
        [HttpPost]
        [Route(nameof(Create))]
        public IActionResult Create(Employee value)
        {
            if (value.Email == null)
            {
                return BadRequest();
            }
            try
            {
                create.Create(value);
                return Ok();
            }
            catch (EmployeeAlreadyExistsException)
            {
                return NotFound();
            }
        }

        // DELETE api/Employee/juan
        [HttpDelete("{email}")]
        [Route(nameof(Delete))]
        public IActionResult Delete(string email)
        {
            if (email == null)
            {
                return BadRequest();
            }
            try
            {
                delete.Delete(email);
                return Ok();
            }
            catch (NotFoundEmployeeException)
            {
                return NotFound();
            }
        }
    }
}