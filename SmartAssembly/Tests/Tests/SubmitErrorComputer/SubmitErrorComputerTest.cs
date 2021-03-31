using Application.Computers.Commands.Build.Directors;
using Application.Computers.Commands.Build.Requests;
using Application.Orders.Commands.Build;
using Application.Orders.Commands.Deliver;
using Application.Orders.Commands.RegisterErrorOrderDelivered;
using Application.Orders.Commands.Create;
using Application.Repositories.Orders.Interfaces;
using Application.Repositories.TypeUses.Interfaces;
using Domain.Computers;
using Domain.Importance;
using Domain.Orders.States;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

namespace Tests
{
    [TestClass]
    public class SubmitErrorComputerTest
    {
        [TestMethod]
        public void SubmitError()
        {
            var container = new DependencyContainerMock();
            var request = new ComputerRequest(TypeUse.gaming, 1200000, Importance.Price, container.Resolve<ITypeUseReadOnlyRepository>());
            var director = container.Resolve<IDirectorComputer>();
            var resultDirector = director.Build(request);
            var computer = resultDirector.Computers.ElementAt(0);
            var submitOrder = container.Resolve<ICreateOrder>();
            submitOrder.Add(computer, 3);
            var order = submitOrder.Submit("juan@gmail", "comentario de prueba").Order;

            var lastOrder = container.Resolve<IBuilderOrder>().GetOrdersByEmployee(order.Employee.Email).Last();
            container.Resolve<IBuilderOrder>().Build(lastOrder);

            var deliverOrder = container.Resolve<IDeliverOrder>();
            var ordersClient = deliverOrder.GetOrdersToDeliverByClient("juan@gmail");
            deliverOrder.Deliver(ordersClient.Last());

            var registerError = container.Resolve<IRegisterErrorOrderDelivered>();
            var lastOrderDelivered = registerError.GetOrdersDeliveredByClient("juan@gmail").Last();
            registerError.Register(lastOrder.Computers.ElementAt(0), "error de prueba");
            var OrderWithError = container.Resolve<IOrderReadOnlyRepository>().All.FirstOrDefault(c => c.Id == lastOrder.Id);

            Assert.IsTrue(OrderWithError.State == OrderState.Error);
        }
    }
}
