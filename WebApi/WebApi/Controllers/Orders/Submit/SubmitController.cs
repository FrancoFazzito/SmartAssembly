using Application.Orders.Commands.Create;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Net;

namespace WebApi.Controllers.Orders.Submit
{
    [ApiController]
    [Produces("application/json")]
    [Route("api/order/[controller]")]
    public class SubmitController : ControllerBase
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
    }
}