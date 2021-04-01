using Application.Components.Commands.Update;
using Application.Repositories.Components.Interfaces;
using Application.Repositories.Interfaces;
using Domain.Components;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

namespace Tests
{
    [TestClass]
    public class UpdateComponentTest
    {
        [TestMethod]
        public void Update()
        {
            var container = new DependencyContainerMock();
            var componentOld = container.Resolve<IComponentReadOnlyRepository>().All.First();
            var componentUpdate = container.Resolve<IComponentReadOnlyRepository>().All.First();
            var newName = $"{componentUpdate.Name} modified";
            componentUpdate.Name = newName;
            new UpdateComponent(container.Resolve<IUpdate<Component>>()).Update(componentUpdate);
            Assert.IsTrue(componentUpdate != null);
            new UpdateComponent(container.Resolve<IUpdate<Component>>()).Update(componentOld);
        }
    }
}