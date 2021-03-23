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
using Domain.Orders.States;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

namespace Tests
{
    [TestClass]
    public class SubmitTest
    {

        [TestMethod]
        public void TestSubmitOrder()
        {
            var container = new DependencyContainerMock();
            var oldCount = container.Resolve<IOrderReadOnlyRepository>().All.Count();
            var computer = new DirectorComputer(new BuilderComputer(new ComputerRequest(TypeUse.gaming, 1200000, container.Resolve<ITypeUseReadOnlyRepository>()), Importance.Price, container.Resolve<IStrategyOrderBy>(), container.Resolve<IFactoryCompatibility>(), container.Resolve<IFactoryEnough>(), container.Resolve<IComponentReadOnlyRepository>())).Build().Computers.ElementAt(0);
            var repoOrder = container.Resolve<IOrderWriteOnlyRepository>();
            var repoEmployee = container.Resolve<IEmployeeReadOnlyRepository>();
            var repoClient = container.Resolve<IClientReadOnlyRepository>();
            var order = new OrderHandler(repoOrder, repoEmployee, repoClient); //ver si poner un mediator en el medio para la application
            var Quantity = 2;
            order.Add(computer, Quantity);
            order.Submit("juan@gmail", "maincra");
            var newCount = container.Resolve<IOrderReadOnlyRepository>().All.Count();
            var lastOrder = container.Resolve<IOrderReadOnlyRepository>().All.Last();
            Assert.IsTrue((newCount - oldCount) == Quantity && lastOrder != null && lastOrder.State == OrderState.Uncompleted);
        }
    }
}
