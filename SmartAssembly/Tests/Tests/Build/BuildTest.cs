using Application.Commands.Build.Builders;
using Application.Commands.Build.Directors;
using Application.Commands.Build.Importances;
using Application.Commands.Build.Request;
using Application.Commands.Build.Specifications;
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
    public class BuildTest
    {
        [TestMethod]
        public void TestBuildComputer()
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
    }
}
