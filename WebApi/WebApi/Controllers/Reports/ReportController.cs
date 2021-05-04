using Application.Common.Exceptions;
using Application.Reports.Commands.Create;
using Domain.Components;
using Domain.Orders;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Net;

namespace WebApi.Controllers.Reports
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class ReportController : ControllerBase
    {
        private readonly ICreateReport createReport;

        public ReportController(ICreateReport createReport)
        {
            this.createReport = createReport;
        }

        private void Create(DateTime since, DateTime until)
        {
            createReport.Create(since, until);
        }

        [HttpGet]
        [Route("Order/delivered")]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(ApiResponse<IEnumerable<Order>>))]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public IActionResult Deliver(DateTime since, DateTime until)
        {
            try
            {
                Create(since, until);
                return Ok(new ApiResponse<IEnumerable<Order>>(createReport.OrdersDelivered));
            }
            catch (InvalidDateException)
            {
                return BadRequest();
            }
        }

        [HttpGet]
        [Route("Order/requested")]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(ApiResponse<IEnumerable<Order>>))]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public IActionResult Requested(DateTime since, DateTime until)
        {
            try
            {
                Create(since, until);
                return Ok(new ApiResponse<IEnumerable<Order>>(createReport.OrdersRequested));
            }
            catch (InvalidDateException)
            {
                return BadRequest();
            }
        }

        [HttpGet]
        [Route("Order/error")]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(ApiResponse<IEnumerable<Order>>))]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public IActionResult Error(DateTime since, DateTime until)
        {
            try
            {
                Create(since, until);
                return Ok(new ApiResponse<IEnumerable<Order>>(createReport.OrdersWithError));
            }
            catch (InvalidDateException)
            {
                return BadRequest();
            }
        }

        [HttpGet]
        [Route("Component")]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(ApiResponse<IEnumerable<Component>>))]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public IActionResult Components(DateTime since, DateTime until)
        {
            try
            {
                Create(since, until);
                return Ok(new ApiResponse<IEnumerable<KeyValuePair<string, int>>>(createReport.MostRequestedComponents));
            }
            catch (InvalidDateException)
            {
                return BadRequest();
            }
        }
    }
}