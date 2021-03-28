using Application.Commands.BuildComputers.Builders;
using Application.Commands.BuildComputers.Directors;
using Application.Commands.BuildComputers.Importances;
using Application.Commands.BuildComputers.Orders;
using Application.Commands.BuildComputers.Request;
using Application.Commands.BuildOrders;
using Application.Factories.Compatibilities;
using Application.Factories.Enoughs;
using Application.Repositories.Components.Interfaces;
using Application.Repositories.Employees.Interfaces;
using Application.Repositories.Interfaces.Clients;
using Application.Repositories.Interfaces.Computers;
using Application.Repositories.Orders.Interfaces;
using Application.Repositories.TypeUses.Interfaces;
using Application.Strategies.OrderBy;
using Domain.Computers;
using Domain.Orders.States;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

namespace Tests
{
    [TestClass]
    public class BuildOrderTest
    {
        [TestMethod]
        public void BuildOrder()
        {
            var container = new DependencyContainerMock();
            var request = new ComputerRequest(TypeUse.gaming, 1200000, Importance.Price, container.Resolve<ITypeUseReadOnlyRepository>());
            var director = container.Resolve<IDirectorComputer>();
            var resultDirector = director.Build(request);
            var computer = resultDirector.Computers.ElementAt(0);
            var submitOrder = container.Resolve<ISubmitOrder>();
            submitOrder.Add(computer, 3);
            var order = submitOrder.Submit("juan@gmail", "comentario de prueba");
            var lastOrder = container.Resolve<IBuilderOrder>().GetOrdersByEmployee(order.Employee.Email).Last();
            var result = container.Resolve<IBuilderOrder>().Build(lastOrder);
            var orderBuilded = container.Resolve<IOrderReadOnlyRepository>().GetById(result.OrderBuilded.Id);
            Assert.IsTrue(orderBuilded.State == OrderState.Completed);
        }
    }
}
