using Application.Common.Exceptions;
using Application.Costs.Commands.Update;
using Application.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Net;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApi.Controllers.Configuration
{
    [Route("api/[controller]")]
    [Produces("application/json")]
    [ApiController]
    public class CostController : ControllerBase
    {
        private readonly IUpdateCost update;
        private readonly ICostsReadOnlyRepository read;

        public CostController(IUpdateCost update, ICostsReadOnlyRepository read)
        {
            this.update = update;
            this.read = read;
        }

        // GET api/cost
        [HttpGet]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(ApiResponse<IEnumerable<Tuple<string, int>>>))]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public IActionResult Get()
        {
            return Ok(new ApiResponse<IEnumerable<Tuple<string, int>>>(read.All));
        }


        // PUT api/Cost/5
        [HttpPut("{name}")]
        [Route(nameof(Update))]
        public IActionResult Update(CostParam costParam)
        {
            if (!costParam.Value.HasValue)
            {
                return BadRequest();
            }
            try
            {
                update.Update(costParam.Name, costParam.Value);
                return Ok();
            }
            catch (NotFoundCostException)
            {
                return NotFound();
            }
        }
    }
}