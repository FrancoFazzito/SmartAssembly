using Application.Common.Exceptions;
using Application.Computers.Commands.Build;
using Application.Computers.Commands.Delete;
using Application.Repositories.Interfaces;
using Domain.Computers;
using Domain.Importance;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Net;

namespace WebApi.Controllers.Computers
{
    [ApiController]
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class ComputerController : ControllerBase
    {
        private readonly IDirectorComputer director;
        private readonly ITypeUseReadOnlyRepository typeRepo;
        private readonly DeleteComputer delete;

        public ComputerController(IDirectorComputer director, ITypeUseReadOnlyRepository typeRepo, Startup.DeleteByIdResolver deleteAccesor, IComputerReadOnlyRepository read)
        {
            this.director = director;
            this.typeRepo = typeRepo;
            delete = new DeleteComputer(deleteAccesor(WebApi.DeletesID.Computer), read);
        }

        // GET /api/computer?price=value&use=value&importance=value
        [HttpGet]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(ApiResponse<IEnumerable<Computer>>))]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public IActionResult Get(decimal? price, string use, string importance)
        {
            if (!price.HasValue)
            {
                return BadRequest();
            }

            if (use == null)
            {
                return BadRequest();
            }

            if (!Enum.TryParse(importance, true, out Importance typeImportance))
            {
                return BadRequest();
            }

            try
            {
                var computers = director.Build(new ComputerRequest(use, price, typeImportance, typeRepo)).Computers;
                return base.Ok(new ApiResponse<IEnumerable<Computer>>(computers));
            }
            catch (NotAvailableComputersException)
            {
                return NotFound();
            }
        }

        // DELETE /api/computer/10
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
                return Ok();
            }
            catch (NotFoundComputerException)
            {
                return NotFound();
            }
        }
    }
}