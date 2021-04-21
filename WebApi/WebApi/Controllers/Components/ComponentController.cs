using System.Collections.Generic;
using Application.Components.Commands.Delete;
using Application.Orders.Commands.RegisterError;
using Application.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers.Components
{
    [Route("api/[controller]")]
    [ApiController]
    public class ComponentController : ControllerBase
    {
        private readonly DeleteComponent delete;

        public ComponentController(Startup.DeleteByIdResolver deleteAccesor, IComponentReadOnlyRepository read)
        {
            delete = new DeleteComponent(deleteAccesor(WebApi.Delete.Component), read);
        }


        //// GET: api/<ComponentController>
        //[HttpGet]
        //public IEnumerable<string> Get()
        //{
        //    return new string[] { "value1", "value2" };
        //}

        //// GET api/<ComponentController>/5
        //[HttpGet("{id}")]
        //public string Get(int id)
        //{
        //    return "value";
        //}

        //// POST api/<ComponentController>
        //[HttpPost]
        //public void Post([FromBody] string value)
        //{
        //}

        //// PUT api/<ComponentController>/5
        //[HttpPut("{id}")]
        //public void Put(int id, [FromBody] string value)
        //{
        //}

        // DELETE api/component/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int? id)
        {
            if (!id.HasValue)
            {
                return BadRequest();
            }
            try
            {
                delete.Delete(id);
                return Ok();
            }
            catch (NotFoundComponentException)
            {
                return NotFound();
            }
        }
    }
}
