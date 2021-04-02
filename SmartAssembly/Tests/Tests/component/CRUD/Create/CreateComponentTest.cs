using Application.Components.Commands.Create;
using Application.Components.Commands.Delete;
using Application.Repositories.Interfaces;
using Domain.Components;
using Domain.Components.Types;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

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
            new DeleteComponent(container.Resolve<IDeleteById>(typeof(Component).ToString())).Delete(componentAdded.Id);
        }
    }
}