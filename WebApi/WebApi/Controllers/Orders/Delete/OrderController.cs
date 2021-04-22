using Application.Orders.Commands.Create;
using Application.Orders.Commands.Delete;
using Application.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers.Orders.Delete
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly DeleteOrder delete;

        public OrderController(Startup.DeleteByIdResolver deleteAccesor, IOrderReadOnlyRepository read)
        {
            delete = new DeleteOrder(deleteAccesor(WebApi.Delete.Order), read);
        }

        //DELETE api/order/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int? id)
        {
            if (!id.HasValue)
            {
                return BadRequest();
            }
            try
            {
                delete.Delete(id);
                return Ok();
            }
            catch (NotFoundOrderException)
            {
                return NotFound();
            }
        }
    }
}
