using Application.Computers.Commands.Build;
using Application.Orders.Commands.Create;
using Application.Repositories.Interfaces;
using Domain.Computers;
using Domain.Importance;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("api/BuildComputer")]
    public class BuildComputerController : ControllerBase
    {
        private readonly IDirectorComputer directorComputer;
        private readonly ITypeUseReadOnlyRepository typeRepo;
        private readonly ICreateOrder createOrder;

        public BuildComputerController(IDirectorComputer director, ITypeUseReadOnlyRepository typeRepo, ICreateOrder createOrder)
        {
            this.directorComputer = director;
            this.typeRepo = typeRepo;
            this.createOrder = createOrder;
        }

        [HttpGet]
        public ClientParam GetExample()
        {
            return new ClientParam() { Email = "juan@gmail.com", Commentary = "aaa" };
        }

        // GET api/price/use/importance
        [HttpGet("{price}/{use}/{importance}")]
        public IEnumerable<Computer> GetComputers(decimal price, string use, string importance)
        {
            return directorComputer.Build(new ComputerRequest((TypeUse)Enum.Parse(typeof(TypeUse), use), price, (Importance)Enum.Parse(typeof(Importance), importance), typeRepo)).Computers;
        }

        [HttpPost]
        [Route("add")]
        public void Add(ComputerParam request)
        {
            createOrder.Add(request.Computer, request.Quantity);
        }

        [HttpPost]
        [Route("submit")]
        public void Submit([FromBody] ClientParam client)
        {
            createOrder.Submit(client.Email, client.Commentary);
        }
    }
}
