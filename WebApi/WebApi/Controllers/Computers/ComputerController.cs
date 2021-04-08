using Application.Computers.Commands.Build;
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

        public ComputerController(IDirectorComputer director, ITypeUseReadOnlyRepository typeRepo)
        {
            this.director = director;
            this.typeRepo = typeRepo;
        }

        // GET /api/computer?price=value&use=value&importance=value
        [HttpGet]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(ApiResponse<IEnumerable<Domain.Computers.Computer>>))]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public IActionResult Get(decimal? price, string use, string importance)
        {
            if (!price.HasValue)
            {
                return BadRequest();
            }

            if (!Enum.TryParse(use, true, out TypeUse typeUse))
            {
                return BadRequest();
            }

            if (!Enum.TryParse(importance, true, out Importance typeImportance))
            {
                return BadRequest();
            }

            try
            {
                var computers = director.Build(new ComputerRequest(typeUse, price, typeImportance, typeRepo)).Computers;
                return base.Ok(new ApiResponse<IEnumerable<Domain.Computers.Computer>>(computers));
            }
            catch (NotAvailableComputersException ex)
            {
                return NotFound(ex.Message);
            }
        }
    }
}