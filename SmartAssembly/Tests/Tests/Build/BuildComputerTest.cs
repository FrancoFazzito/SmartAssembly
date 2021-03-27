using Application.Commands.BuildComputers.Builders;
using Application.Commands.BuildComputers.Directors;
using Application.Commands.BuildComputers.Importances;
using Application.Commands.BuildComputers.Request;
using Application.Commands.BuildComputers.Specifications;
using Application.Factories.Compatibilities;
using Application.Factories.Enoughs;
using Application.Repositories.Components.Interfaces;
using Application.Repositories.TypeUses.Interfaces;
using Application.Strategies.OrderBy;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

namespace Tests
{
    [TestClass]
    public class BuildComputerTest
    {
        [TestMethod]
        public void BuildComputer()
        {
            var container = new DependencyContainerMock();
            var request = new ComputerRequest(TypeUse.gaming, 1200000, container.Resolve<ITypeUseReadOnlyRepository>());
            var orderBy = container.Resolve<IStrategyOrderBy>();
            var factoryCompatibility = container.Resolve<IFactoryCompatibility>();
            var factoryEnough = container.Resolve<IFactoryEnough>();
            var componentRepository = container.Resolve<IComponentReadOnlyRepository>();
            var builder = new BuilderComputer(request, Importance.Price, orderBy, factoryCompatibility, factoryEnough, componentRepository);
            var computers = new DirectorComputer(builder).Build().Computers;
            Assert.IsTrue(computers.Count() > 0);
        }

        [TestMethod]
        [ExpectedException(typeof(NotAvailableComputersException))]
        public void BuildComputerWithouthCorrectPrice()
        {
            var container = new DependencyContainerMock();
            var request = new ComputerRequest(TypeUse.gaming, 0, container.Resolve<ITypeUseReadOnlyRepository>());
            var orderBy = container.Resolve<IStrategyOrderBy>();
            var factoryCompatibility = container.Resolve<IFactoryCompatibility>();
            var factoryEnough = container.Resolve<IFactoryEnough>();
            var componentRepository = container.Resolve<IComponentReadOnlyRepository>();
            var builder = new BuilderComputer(request, Importance.Price, orderBy, factoryCompatibility, factoryEnough, componentRepository);
            var computers = new DirectorComputer(builder).Build().Computers;
        }
    }
}
