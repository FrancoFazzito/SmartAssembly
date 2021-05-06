using Application.Common.Exceptions;
using Application.Components.Commands.Create;
using Application.Components.Commands.Delete;
using Application.Components.Commands.Read;
using Application.Components.Commands.Update;
using Application.Repositories.Interfaces;
using Domain.Components;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Net;

namespace WebApi.Controllers.Components
{
    [Route("api/[controller]")]
    [Produces("application/json")]
    [ApiController]
    public partial class ComponentController : ControllerBase
    {
        private readonly DeleteComponent delete;
        private readonly CreateComponent create;
        private readonly UpdateComponent update;
        private readonly ReadComponent read;

        public ComponentController(Startup.DeleteByIdResolver deleteAccesor, IComponentReadOnlyRepository readComponent, ICreate<Component> createComponent, IUpdate<Component> updateComponent)
        {
            delete = new DeleteComponent(deleteAccesor(WebApi.DeletesID.Component), readComponent);
            create = new CreateComponent(createComponent, readComponent);
            update = new UpdateComponent(updateComponent, readComponent);
            read = new ReadComponent(readComponent);
        }

        // GET: api/component
        [HttpGet]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(ApiResponse<IEnumerable<Component>>))]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public IActionResult Get()
        {
            try
            {
                return Ok(new ApiResponse<IEnumerable<Component>>(read.All));
            }
            catch
            {
                return NotFound();
            }
            
        }

        // PUT api/component/5
        [HttpPut("{id}")]
        [Route(nameof(Update))]
        public IActionResult Update(ComponentParam param)
        {
            if (!param.Id.HasValue)
            {
                return BadRequest();
            }
            if (param.Component.Name != null && param.Component.Name != string.Empty)
            {
                update.Update(param.Id, param.Component);
                return BadRequest();
            }
            try
            {
                return NoContent();
            }
            catch (NotFoundComponentException)
            {
                return NotFound();
            }
        }

        // POST api/component
        [HttpPost]
        [Route(nameof(Create))]
        public IActionResult Create(Component component)
        {
            if (component.Name != null && component.Name == string.Empty)
            {
                return BadRequest();
            }
            try
            {
                create.Create(component);
                return NoContent();
            }
            catch (ComponentAlreadyExistException)
            {
                return BadRequest();
            }
        }

        // DELETE api/component/5
        [HttpDelete("{id}")]
        [Route(nameof(Delete))]
        public IActionResult Delete(int? id)
        {
            if (!id.HasValue)
            {
                return BadRequest();
            }
            try
            {
                delete.Delete(id);
                return NoContent();
            }
            catch (NotFoundComponentException)
            {
                return NotFound();
            }
        }
    }
}