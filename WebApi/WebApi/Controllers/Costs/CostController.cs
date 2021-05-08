using Application.Common.Exceptions;
using Application.Costs.Commands.Update;
using Application.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Net;
using WebApi.Controllers.Costs;

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
            try
            {
                return Ok(new ApiResponse<IEnumerable<Tuple<string, int>>>(read.All));
            }
            catch (Exception)
            {
                return NotFound();
            }
            
        }


        // PUT api/Cost/5
        [HttpPut]
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
                return NoContent();
            }
            catch (NotFoundCostException)
            {
                return NotFound();
            }
        }
    }
}