using Application.Components.Commands.Create;
using Application.Components.Commands.Delete;
using Application.Components.Commands.Read;
using Application.Components.Commands.Update;
using Application.Orders.Commands.RegisterError;
using Application.Repositories.Interfaces;
using Domain.Components;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace WebApi.Controllers.Components
{
    [Route("api/[controller]")]
    [ApiController]
    public class ComponentController : ControllerBase
    {
        private readonly DeleteComponent delete;
        private readonly CreateComponent create;
        private readonly UpdateComponent update;
        private readonly ReadComponent read;

        public ComponentController(Startup.DeleteByIdResolver deleteAccesor, IComponentReadOnlyRepository readComponent, ICreate<Component> createComponent, IUpdate<Component> updateComponent)
        {
            delete = new DeleteComponent(deleteAccesor(WebApi.Delete.Component), readComponent);
            create = new CreateComponent(createComponent, readComponent);
            update = new UpdateComponent(updateComponent, readComponent);
            read = new ReadComponent(readComponent);
        }

        // GET: api/component
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(new ApiResponse<IEnumerable<Component>>(read.All));
        }

        // PUT api/component/5
        [HttpPut("{id}")]
        public IActionResult Update(int? id, Component component)
        {
            if (!id.HasValue)
            {
                return BadRequest();
            }
            if (component.Name != null && component.Name != string.Empty)
            {
                update.Update(id, component);
                return BadRequest();
            }
            try
            {
                return Ok();
            }
            catch (NotFoundComponentException)
            {
                return NotFound();
            }
        }

        // POST api/component
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
