using Application.Common.Exceptions;
using Application.Reports.Commands.Create;
using Domain.Orders;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace WebApi.Controllers.Reports
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReportController : ControllerBase
    {
        private readonly ICreateReport createReport;

        public ReportController(ICreateReport createReport)
        {
            this.createReport = createReport;
        }

        public void Create(DateTime since, DateTime until)
        {
            createReport.Create(since, until);
        }

        [HttpGet]
        [Route("Order/delivered")]
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
