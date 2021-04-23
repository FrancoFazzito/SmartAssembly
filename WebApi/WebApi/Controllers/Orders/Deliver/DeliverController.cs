using Application.Common.Exceptions;
using Application.Orders.Commands.Build;
using Application.Orders.Commands.Create;
using Application.Orders.Commands.Deliver;
using Domain.Orders;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Net;

namespace WebApi.Controllers.Orders.Deliver
{
    [ApiController]
    [Produces("application/json")]
    [Route("api/order/[controller]")]
    public class DeliverController : ControllerBase
    {
        private readonly IDeliverOrder deliver;

        public DeliverController(IDeliverOrder deliver)
        {
            this.deliver = deliver;
        }

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
                var orders = deliver.GetOrdersToDeliverByClient(email).ToList();
                return Ok(new ApiResponse<IEnumerable<Order>>(orders));
            }
            catch (NotAvailableOrdersException)
            {
                return NotFound();
            }
        }

        [HttpPost]
        [Route(nameof(Deliver))]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(ApiResponse<SubmitResult>))]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public IActionResult Deliver(int? id)
        {
            if (!id.HasValue)
            {
                return BadRequest();
            }
            try
            {
                var result = deliver.Deliver(id);
                return Ok(result);
            }
            catch (NotFoundOrderException)
            {
                return BadRequest();
            }
            catch (NotCompletedOrderException)
            {
                return BadRequest();
            }
        }
    }
}