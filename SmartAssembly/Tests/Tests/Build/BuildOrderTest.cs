using Application.Commands.BuildComputers.Builders;
using Application.Commands.BuildComputers.Directors;
using Application.Commands.BuildComputers.Importances;
using Application.Commands.BuildComputers.Orders;
using Application.Commands.BuildComputers.Request;
using Application.Commands.BuildComputers.Specifications;
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
using Application.Commands.BuildOrders;


namespace Tests
{
    [TestClass]
    public class BuildOrderTest
    {
        [TestMethod]
        public void TestBuildOrder()
        {
            var container = new DependencyContainerMock();
            var computer = new DirectorComputer(new BuilderComputer(new ComputerRequest(TypeUse.gaming, 1200000, container.Resolve<ITypeUseReadOnlyRepository>()), Importance.Price, container.Resolve<IStrategyOrderBy>(), container.Resolve<IFactoryCompatibility>(), container.Resolve<IFactoryEnough>(), container.Resolve<IComponentReadOnlyRepository>())).Build().Computers.ElementAt(0);
            var repoOrder = container.Resolve<ISubmitOrderRepository>();
            var repoEmployee = container.Resolve<IEmployeeReadOnlyRepository>();
            var repoClient = container.Resolve<IClientReadOnlyRepository>();
            var submitOrder = new SubmitOrder(repoOrder, repoEmployee, repoClient); //ver si poner un mediator en el medio para la application
            var Quantity = 2;
            submitOrder.Add(computer, Quantity);
            var order = submitOrder.Submit("juan@gmail", "maincra 0");
            var builder = container.Resolve<IBuilderOrder>();
            order = builder.GetOrdersByEmployee(order.Employee.Email).Last();
            var result = builder.Build(order);
            order = container.Resolve<IOrderReadOnlyRepository>().GetById(result.OrderBuilded.Id);
            Assert.IsTrue(order.State == OrderState.Completed);
        }
    }
}
