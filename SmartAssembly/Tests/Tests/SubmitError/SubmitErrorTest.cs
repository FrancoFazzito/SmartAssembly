using Application.Commands.Build.Builders;
using Application.Commands.Build.Directors;
using Application.Commands.Build.Importances;
using Application.Commands.Build.Orders;
using Application.Commands.Build.Request;
using Application.Commands.Build.Specifications;
using Application.Commands.RegisterComputerError.Errors;
using Application.Factories.Compatibilities;
using Application.Factories.Enoughs;
using Application.Repositories.Components.Interfaces;
using Application.Repositories.Employees.Interfaces;
using Application.Repositories.Interfaces.Clients;
using Application.Repositories.Interfaces.Error;
using Application.Repositories.Orders.Interfaces;
using Application.Repositories.TypeUses.Interfaces;
using Application.Strategies.OrderBy;
using Domain.Orders.States;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

namespace Tests
{
    [TestClass]
    public class SubmitErrorTest
    {
        [TestMethod]
        public void TestSubmitError()
        {
            var container = new DependencyContainerMock();
            var computer = new DirectorComputer(new BuilderComputer(new ComputerRequest(TypeUse.gaming, 1200000, container.Resolve<ITypeUseReadOnlyRepository>()), Importance.Price, container.Resolve<IStrategyOrderBy>(), container.Resolve<IFactoryCompatibility>(), container.Resolve<IFactoryEnough>(), container.Resolve<IComponentReadOnlyRepository>())).Build().Computers.ElementAt(0);
            var repoOrder = container.Resolve<IOrderWriteOnlyRepository>();
            var repoEmployee = container.Resolve<IEmployeeReadOnlyRepository>();
            var repoClient = container.Resolve<IClientReadOnlyRepository>();
            var order = new OrderHandler(repoOrder, repoEmployee, repoClient); //ver si poner un mediator en el medio para la application
            var Quantity = 2;
            order.Add(computer, Quantity);
            order.Submit("juan@gmail", "maincra");
            var lastOrder = container.Resolve<IOrderReadOnlyRepository>().All.Last();
            var error = new RegisterError(lastOrder.Computers.ElementAt(0), container.Resolve<IComponentReadOnlyRepository>(), container.Resolve<IFactoryCompatibility>(), container.Resolve<IFactoryEnough>(), container.Resolve<IErrorWriteOnlyRepository>());
            var errorResult = error.Register(computer.Components.ElementAt(0), "error de inicio");
            lastOrder = container.Resolve<IOrderReadOnlyRepository>().All.Last();
            Assert.IsTrue(lastOrder != null && lastOrder.State == OrderState.Mistake && errorResult != null);
        }
    }
}
