using Application.Orders.Commands.Create;
using Domain.Orders;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Net;

namespace WebApi.Controllers.Orders.Submit
{
    
    [Produces("application/json")]
    [Route("api/order/[controller]")]
    [ApiController]
    public partial class SubmitController : ControllerBase
    {
        private readonly ISubmitOrder submit;

        public SubmitController(ISubmitOrder submit)
        {
            this.submit = submit;
        }

        //POST api/order/submit
        [HttpPost]
        [Route(nameof(Submit))]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(ApiResponse<SubmitResult>))]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public IActionResult Submit(OrderParam order)
        {
            if (!order.Order.Computers.Any())
            {
                return BadRequest();
            }
            try
            {
                var result = submit.Submit(order.Order, order.Email);
                return Ok(new ApiResponse<SubmitResult>(result));
            }
            catch (AddStockException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [Route(nameof(Add))]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(ApiResponse<SubmitResult>))]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public IActionResult Add(AddOrderParam addOrder)
        {
            if (addOrder.computer == null || addOrder.Order == null)
            {
                return BadRequest();
            }
            if (!addOrder.quantity.HasValue)
            {
                return BadRequest();
            }
            if (addOrder.quantity <= 0)
            {
                return BadRequest();
            }
            try
            {
                var result = submit.AddComputer(addOrder.Order, addOrder.computer, addOrder.quantity);
                return Ok(new ApiResponse<Order>(result));
            }
            catch (AddStockException ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}