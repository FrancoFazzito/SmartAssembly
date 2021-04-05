using Application.Computers.Commands.Build;
using Application.Repositories.Interfaces;
using Domain.Computers;
using Domain.Importance;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BuilderComputerController : ControllerBase
    {
        private readonly IDirectorComputer director;
        private readonly ITypeUseReadOnlyRepository typeRepo;

        public BuilderComputerController(IDirectorComputer director, ITypeUseReadOnlyRepository typeRepo)
        {
            this.director = director;
            this.typeRepo = typeRepo;
        }

        [HttpGet]
        public string GetCExample()
        {
            return "120000/gaming/price";
        }

        // GET api/price/use/importance
        [HttpGet("{price}/{use}/{importance}")]
        public IEnumerable<Computer> GetComputers(decimal price, string use, string importance)
        {
            return director.Build(new ComputerRequest((TypeUse)Enum.Parse(typeof(TypeUse), use), price, (Importance)Enum.Parse(typeof(Importance), importance), typeRepo)).Computers;
        }
    }
}
