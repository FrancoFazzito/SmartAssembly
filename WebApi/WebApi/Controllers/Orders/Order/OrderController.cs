using Application.Common.Exceptions;
using Application.Orders.Commands.Create;
using Application.Orders.Commands.Delete;
using Application.Orders.Commands.Read;
using Application.Repositories.Interfaces;
using Domain.Orders;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace WebApi.Controllers.Orders.Delete
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly DeleteOrder delete;
        private readonly ReadOrder read;


        public OrderController(Startup.DeleteByIdResolver deleteAccesor, IOrderReadOnlyRepository readOrder)
        {
            delete = new DeleteOrder(deleteAccesor(DeletesID.Order), readOrder);
            read = new ReadOrder(readOrder);
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

        //GET api/order
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(new ApiResponse<IEnumerable<Order>>(read.All));
        }
    }
}
