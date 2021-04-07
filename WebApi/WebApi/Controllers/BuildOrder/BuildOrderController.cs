using Application.Orders.Commands.Build;
using Domain.Orders;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Net;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApi.Controllers.BuildOrder
{
    [ApiController]
    [Produces("application/json")]
    [Route("api/buildOrder")]
    public class BuildOrderController : ControllerBase
    {
        private readonly IBuilderOrder builderOrder;

        public BuildOrderController(IBuilderOrder builderOrder)
        {
            this.builderOrder = builderOrder;
        }

        // GET: api/buildOrder/email
        [HttpGet("{email}")]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(ApiResponse<IEnumerable<Order>>))]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public IActionResult GetOrdersByEmail(string email)
        {
            var orders = builderOrder.GetOrdersByEmployee(email).ToList();
            return Ok(new ApiResponse<IEnumerable<Order>>(orders));
        }

        // POST api/buildOrder/build
        [HttpPost]
        [Route("build")]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(ApiResponse<BuilderOrderResult>))]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public IActionResult Build([FromBody] int id)
        {
            var buildResult = builderOrder.Build(id);
            return Ok(new ApiResponse<BuilderOrderResult>(buildResult));
        }
    }
}