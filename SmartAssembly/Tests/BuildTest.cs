using Application.Commands.Build.Builders;
using Application.Commands.Build.Directors;
using Application.Commands.Build.Importances;
using Application.Commands.Build.Orders;
using Application.Commands.Build.Request;
using Application.Commands.Build.Specifications;
using Application.Factories.Compatibilities;
using Application.Factories.Enoughs;
using Application.Repositories.Components.Interfaces;
using Application.Repositories.Employees.Interfaces;
using Application.Repositories.Interfaces.Clients;
using Application.Repositories.Orders.Interfaces;
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

        [TestMethod]
        public void TestSubmitOrder()
        {
            var container = new DependencyContainerMock();
            var oldCount = container.Resolve<IOrderReadOnlyRepository>().All.Count();
            var computer = new DirectorComputer(new BuilderComputer(new ComputerRequest(TypeUse.gaming, 1200000, container.Resolve<ITypeUseReadOnlyRepository>()), Importance.Price, container.Resolve<IStrategyOrderBy>(), container.Resolve<IFactoryCompatibility>(), container.Resolve<IFactoryEnough>(), container.Resolve<IComponentReadOnlyRepository>())).Build().Computers.ElementAt(0);
            var repoOrder = container.Resolve<IOrderWriteOnlyRepository>();
            var repoEmployee = container.Resolve<IEmployeeReadOnlyRepository>();
            var repoClient = container.Resolve<IClientReadOnlyRepository>();
            var order = new OrderHandler(repoOrder, repoEmployee, repoClient);
            var Quantity = 2;
            order.Add(computer, Quantity);
            order.Submit("juan@gmail", "maincra");
            var newCount = container.Resolve<IOrderReadOnlyRepository>().All.Count(); //ver si poner un mediator en el medio para la application
            Assert.IsTrue((newCount - oldCount) == Quantity);
        }

        //private static void RegisterError(Computer computer)
        //{
        //    var factoryCompatibility = container.Resolve<IFactoryCompatibility>();
        //    var factoryEnough = container.Resolve<IFactoryEnough>();
        //    var repository = container.Resolve<IComponentReadOnlyRepository>();
        //    var register = new RegisterError(computer, repository, factoryCompatibility, factoryEnough);
        //    var result = register.Register(computer.Components.ElementAt(0));
        //    Console.WriteLine(result.PriceDiference);
        //}
    }
}
