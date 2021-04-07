using Application.Computers.Commands.Build;
using Application.Orders.Commands.Create;
using Application.Repositories.Interfaces;
using Domain.Computers;
using Domain.Importance;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Net;

namespace WebApi.Controllers
{
    [ApiController]
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class BuildComputerController : ControllerBase
    {
        private readonly IDirectorComputer director;
        private readonly ITypeUseReadOnlyRepository typeRepo;
        private readonly ISubmitOrder createOrder;

        public BuildComputerController(IDirectorComputer director, ITypeUseReadOnlyRepository typeRepo, ISubmitOrder createOrder)
        {
            this.director = director;
            this.typeRepo = typeRepo;
            this.createOrder = createOrder;
        }

        // GET api/buildComputer/price/use/importance
        [HttpGet("{price}/{use}/{importance}")]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(ApiResponse<IEnumerable<Computer>>))]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public IActionResult GetComputers(decimal price, string use, string importance)
        {
            var computers = director.Build(new ComputerRequest((TypeUse)Enum.Parse(typeof(TypeUse), use), price, (Importance)Enum.Parse(typeof(Importance), importance), typeRepo)).Computers;
            return Ok(new ApiResponse<IEnumerable<Computer>>(computers));
        }

        //POST api/buildComputer/submit
        [HttpPost]
        [Route("submit")]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(ApiResponse<SubmitResult>))]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public IActionResult Submit(OrderParam order)
        {
            var result = createOrder.Submit(order.Order, order.Email);
            return Ok(new ApiResponse<SubmitResult>(result));
        }
    }
}
