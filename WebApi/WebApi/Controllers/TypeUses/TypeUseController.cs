using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Application.Common.Exceptions;
using Application.Repositories.Interfaces;
using Application.TypeUse.Commands.Create;
using Application.TypeUse.Commands.Delete;
using Application.TypeUse.Commands.Read;
using Domain.Specification;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApi.Controllers.TypeUses
{
    [Route("api/[controller]")]
    [ApiController]
    public class TypeUseController : ControllerBase
    {
        private readonly DeleteTypeUse delete;
        private readonly CreateTypeUse create;
        private readonly ReadTypeUse read;

        public TypeUseController(Startup.DeleteByNameResolver deleteAccesor, ITypeUseReadOnlyRepository readTypeUses, ICreate<ISpecification> createSpecification)
        {
            delete = new DeleteTypeUse(deleteAccesor(DeletesEmail.Client), readTypeUses);
            create = new CreateTypeUse(createSpecification, readTypeUses);
            read = new ReadTypeUse(readTypeUses);
        }

        // GET: api/TypeUse
        [HttpGet]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(ApiResponse<IEnumerable<ISpecification>>))]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public IActionResult Get()
        {
            return Ok(new ApiResponse<IEnumerable<ISpecification>>(read.All));
        }

        [HttpDelete("{name}")]
        [Route(nameof(Delete))]
        public IActionResult Delete(string name)
        {
            if (name == null)
            {
                return BadRequest();
            }
            try
            {
                delete.Delete(name);
                return Ok();
            }
            catch (NotFoundClientException)
            {
                return NotFound();
            }
        }


        // POST api/TypeUse
        [HttpPost]
        [Route(nameof(Create))]
        public IActionResult Create(ISpecification value)
        {
            if (!value.Cpu.HasValue || !value.Fan.HasValue || !value.Gpu.HasValue || !value.Hdd.HasValue || !value.Ssd.HasValue || !value.Ram.HasValue)
            {
                return BadRequest();
            }

            if (value.Name == null)
            {
                return BadRequest();
            }
            try
            {
                create.Create(value);
                return Ok();
            }
            catch (SpecificationAlreadyExistsException)
            {
                return NotFound();
            }
        }
    }
}
