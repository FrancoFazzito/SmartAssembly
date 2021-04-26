using Application.Common.Exceptions;
using Application.Orders.Commands.Build;
using Application.Orders.Commands.Deliver;
using Domain.Orders;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Net;

namespace WebApi.Controllers.Orders.Build
{
    [ApiController]
    [Produces("application/json")]
    [Route("api/order/[controller]")]
    public class BuildController : ControllerBase
    {
        private readonly IBuilderOrder builder;
        private readonly IDeliverOrder deliver;

        public BuildController(IBuilderOrder builder, IDeliverOrder deliver)
        {
            this.builder = builder;
            this.deliver = deliver;
        }

        // GET: api/order/email
        [HttpGet("{email}")]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(ApiResponse<IEnumerable<Order>>))]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public IActionResult Get(string email)
        {
            if (email == null)
            {
                return BadRequest();
            }
            try
            {
                var orders = builder.GetOrdersByEmployee(email);
                return Ok(new ApiResponse<IEnumerable<Order>>(orders));
            }
            catch (NotAvailableOrdersException)
            {
                return NotFound();
            }
        }

        // POST api/order/build
        [HttpPost]
        [Route(nameof(Build))]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(ApiResponse<BuilderOrderResult>))]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public IActionResult Build([FromBody] int? id)
        {
            if (!id.HasValue)
            {
                return BadRequest();
            }
            try
            {
                var buildResult = builder.Build(id);
                return Ok(new ApiResponse<BuilderOrderResult>(buildResult));
            }
            catch (NotFoundOrderException ex)
            {
                return NotFound(ex.Message);
            }
        }
    }
}