using Application.Computers.Commands.Build.Directors;
using Application.Computers.Commands.Build.Requests;
using Application.Orders.Commands.Build;
using Application.Orders.Commands.Deliver;
using Application.Orders.Commands.Create;
using Application.Reports.Commands.Create;
using Application.Repositories.TypeUses.Interfaces;
using Domain.Computers;
using Domain.Importance;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;
using Domain.Components;
using Domain.Components.Types;
using Application.Components.Commands.Create;
using Application.Repositories.Interfaces;
using Application.Repositories.Components.Interfaces;
using Application.Components.Commands.Delete;

namespace Tests
{
    [TestClass]
    public class CreateComponentTest
    {
        [TestMethod]
        public void Create()
        {
            var container = new DependencyContainerMock();
            var component = new Component()
            {
                Capacity = 1000,
                Channels = 2,
                FanLevel = 10,
                FanSize = 10,
                HasIntegratedVideo = true,
                MaxFrecuency = 3200,
                Name = "example",
                NeedHighFrecuency = false,
                PerfomanceLevel = 10,
                Price = 1000.25M,
                Stock = 10,
                TypeFormat = TypeFormat.ATX,
                TypePart = TypePart.accesory,
                VideoLevel = 10,
                Watts = 1500
            };
            new CreateComponent(container.Resolve<ICreate<Component>>()).Create(component);
            var componentAdded = container.Resolve<IComponentReadOnlyRepository>().All.FirstOrDefault(c => c.Name == "example");
            Assert.IsTrue(component != null);
            new DeleteComponent(container.Resolve<IDelete<Component>>()).Delete(componentAdded.Id);
        }
    }
}
