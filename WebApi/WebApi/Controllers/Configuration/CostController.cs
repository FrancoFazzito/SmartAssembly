using Application.Costs.Commands.Update;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApi.Controllers.Configuration
{
    [Route("api/cost/[controller]")]
    [ApiController]
    public class CostController : ControllerBase
    {
        private readonly IUpdateCost update;

        public CostController(IUpdateCost update)
        {
            this.update = update;
        }

        // PUT api/ConfigurationController/5
        [HttpPut("{name}")]
        public IActionResult Update(string name, [FromBody] int? value)
        {
            if (!value.HasValue)
            {
                return BadRequest();
            }
            try
            {
                update.Update(name,value);
                return Ok();
            }
            catch (NotFoundCostException)
            {
                return NotFound();
            }
        }

        //[HttpGet]
        //public IActionResult GetBuildCost()
        //{

        //    return Ok(new ApiResponse<int>())
        //}
    }
}
