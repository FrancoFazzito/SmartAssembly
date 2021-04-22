using System.Collections.Generic;
using Application.Components.Commands.Create;
using Application.Components.Commands.Delete;
using Application.Orders.Commands.RegisterError;
using Application.Repositories.Interfaces;
using Domain.Components;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers.Components
{
    [Route("api/[controller]")]
    [ApiController]
    public class ComponentController : ControllerBase
    {
        private readonly DeleteComponent delete;
        private readonly CreateComponent create;

        public ComponentController(Startup.DeleteByIdResolver deleteAccesor, IComponentReadOnlyRepository read, ICreate<Component> createComponent)
        {
            delete = new DeleteComponent(deleteAccesor(WebApi.Delete.Component), read);
            create = new CreateComponent(createComponent,read);
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

        // POST api/<ComponentController>
        [HttpPost]
        public IActionResult Post(Component component)
        {
            if (component.Name != null && component.Name != string.Empty)
            {
                return BadRequest();
            }
            try
            {
                create.Create(component);
                return Ok();
            }
            catch (ComponentNameAlreadyExistException)
            {
                return BadRequest();
            }
        }

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
