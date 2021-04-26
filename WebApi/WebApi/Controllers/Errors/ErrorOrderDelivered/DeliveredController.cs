using Application.Common.Exceptions;
using Application.Orders.Commands.RegisterError;
using Domain.Orders;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Net;

namespace WebApi.Controllers.Errors.ErrorOrderDelivered
{
    [Route("api/error/[controller]")]
    [ApiController]
    public class DeliveredController : ControllerBase
    {
        private readonly IRegisterErrorOrderDelivered registerError;

        public DeliveredController(IRegisterErrorOrderDelivered registerError)
        {
            this.registerError = registerError;
        }

        [HttpPost]
        [Route(nameof(Register))]
        public IActionResult Register(ErrorDeliveredParam errorParam)
        {
            if (!errorParam.IdComputer.HasValue)
            {
                return BadRequest();
            }
            try
            {
                registerError.Register(errorParam.IdComputer, errorParam.Commentary);
                return Ok();
            }
            catch (NotFoundComputerException)
            {
                return NotFound();
            }
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
                var orders = registerError.GetOrdersDeliveredByClient(email);
                return Ok(new ApiResponse<IEnumerable<Order>>(orders));
            }
            catch (NotAvailableOrdersException ex)
            {
                return NotFound(ex.Message);
            }
        }
    }
}
