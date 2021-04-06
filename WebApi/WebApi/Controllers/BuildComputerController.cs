using Application.Computers.Commands.Build;
using Application.Orders.Commands.Create;
using Application.Repositories.Interfaces;
using Domain.Computers;
using Domain.Importance;
using Domain.Orders;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("api/buildComputer")]
    public class BuildComputerController : ControllerBase
    {
        private readonly IDirectorComputer director;
        private readonly ITypeUseReadOnlyRepository typeRepo;
        private readonly ICreateOrder createOrder;

        public BuildComputerController(IDirectorComputer director, ITypeUseReadOnlyRepository typeRepo, ICreateOrder createOrder)
        {
            this.director = director;
            this.typeRepo = typeRepo;
            this.createOrder = createOrder;
        }

        [HttpGet]
        public OrderParam GetExample()
        {
            return null;
        }

        // GET api/price/use/importance
        [HttpGet("{price}/{use}/{importance}")]
        public IEnumerable<Computer> GetComputers(decimal price, string use, string importance)
        {
            return director.Build(new ComputerRequest((TypeUse)Enum.Parse(typeof(TypeUse), use), price, (Importance)Enum.Parse(typeof(Importance), importance), typeRepo)).Computers;
        }

        [HttpPost]
        [Route("add")]
        public Order Add(ComputerParam request)
        {
            return createOrder.Add(request.Computer, request.Quantity);
        }


        [HttpPost]
        [Route("remove")]
        public Order Remove(Computer computer)
        {
            return createOrder.Remove(computer);
        }

        [HttpPost]
        [Route("submit")]
        public CreateOrderResult Submit(OrderParam order)
        {
            return createOrder.Submit(order.Order, order.Email);
        }
    }
}
