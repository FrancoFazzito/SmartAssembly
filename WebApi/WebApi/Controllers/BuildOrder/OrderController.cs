using Application.Orders.Commands.Build;
using Application.Orders.Commands.Create;
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
    [Route("api/[controller]")]
    public class OrderController : ControllerBase
    {
        private readonly IBuilderOrder builderOrder;
        private readonly ISubmitOrder submitOrder;

        public OrderController(IBuilderOrder builderOrder, ISubmitOrder submitOrder)
        {
            this.builderOrder = builderOrder;
            this.submitOrder = submitOrder;
        }

        // GET: api/buildOrder/email
        [HttpGet("{email}")]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(ApiResponse<IEnumerable<Order>>))]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public IActionResult GetOrdersByEmail(string email)
        {
            if (email == null)
            {
                return BadRequest();
            }

            try
            {
                var orders = builderOrder.GetOrdersByEmployee(email).ToList();
                return Ok(new ApiResponse<IEnumerable<Order>>(orders));
            }
            catch (NotAvailableOrders ex)
            {
                return NotFound(ex.Message);
            }
        }

        // POST api/buildOrder/build
        [HttpPost(Name = nameof(Build))]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(ApiResponse<BuilderOrderResult>))]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public IActionResult Build([FromBody] int id)
        {
            var buildResult = builderOrder.Build(id);
            return Ok(new ApiResponse<BuilderOrderResult>(buildResult));
        }

        //POST api/buildComputer/submit
        [HttpPost(Name = nameof(Submit))]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(ApiResponse<SubmitResult>))]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public IActionResult Submit([FromBody] OrderParam order)
        {
            var result = submitOrder.Submit(order.Order, order.Email);
            return Ok(new ApiResponse<SubmitResult>(result));
        }
    }
}