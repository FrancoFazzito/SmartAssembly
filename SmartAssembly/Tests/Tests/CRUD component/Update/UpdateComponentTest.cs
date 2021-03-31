using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using Domain.Components;
using Application.Repositories.Interfaces;
using Application.Repositories.Components.Interfaces;
using Application.Components.Commands.Update;

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
            var componentUpdated = container.Resolve<IComponentReadOnlyRepository>().All.FirstOrDefault(c => c.Name == newName);
            Assert.IsTrue(componentUpdate != null);
            new UpdateComponent(container.Resolve<IUpdate<Component>>()).Update(componentOld);
        }
    }


}
