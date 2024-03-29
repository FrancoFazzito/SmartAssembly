﻿using Application.Common.Exceptions;
using Application.Orders.Commands.Delete;
using Application.Orders.Commands.Read;
using Application.Repositories.Interfaces;
using Domain.Orders;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Net;

namespace WebApi.Controllers.Orders.Delete
{
    [Route("api/[controller]")]
    [Produces("application/json")]
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

        //DELETE api/order/Delete/5
        [HttpDelete]
        [Route("delete/{id}")]
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
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(ApiResponse<IEnumerable<Order>>))]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public IActionResult Get()
        {
            try
            {
                return Ok(new ApiResponse<IEnumerable<Order>>(read.All));
            }
            catch
            {
                return NotFound();
            }

        }
    }
}