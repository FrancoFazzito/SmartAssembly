using Application.Components.Commands.Create;
using Application.Components.Commands.Delete;
using Application.Repositories.Interfaces;
using Domain.Components;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

namespace Tests
{
    [TestClass]
    public class DeleteComponentTest
    {
        [TestMethod]
        public void Delete()
        {
            var container = new DependencyContainerMock();
            var componentToAdd = container.Resolve<IComponentReadOnlyRepository>().All.Last();
            var componentToRemove = container.Resolve<IComponentReadOnlyRepository>().All.Last();
            new DeleteComponent(container.Resolve<IDeleteById>(typeof(Component).ToString())).Delete(componentToRemove.Id);
            var componentRemoved = container.Resolve<IComponentReadOnlyRepository>().All.FirstOrDefault(c => c.Id == componentToRemove.Id);
            Assert.IsTrue(componentRemoved == null);
            new CreateComponent(container.Resolve<ICreate<Component>>()).Create(componentToAdd);
        }
    }
}