using Application.Computers.Commands.Build.Directors;
using Application.Computers.Commands.Build.Requests;
using Application.Orders.Commands.Build;
using Application.Orders.Commands.Create;
using Application.Orders.Commands.Deliver;
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
    public class DeliveredTest
    {
        [TestMethod]
        public void DeliverOrder()
        {
            var container = new DependencyContainerMock();
            var request = new ComputerRequest(TypeUse.gaming, 1200000, Importance.Price, container.Resolve<ITypeUseReadOnlyRepository>());
            var director = container.Resolve<IDirectorComputer>();
            var resultDirector = director.Build(request);
            var computer = resultDirector.Computers.ElementAt(0);
            var submitOrder = container.Resolve<ICreateOrder>();
            submitOrder.Add(computer, 3);
            var order = submitOrder.Submit("juan@gmail", "comentario de prueba").Order;

            var builder = container.Resolve<IBuilderOrder>();
            order = builder.GetOrdersByEmployee(order.Employee.Email).Last();
            builder.Build(order);

            var deliverOrder = container.Resolve<IDeliverOrder>();
            var ordersClient = deliverOrder.GetOrdersToDeliverByClient("juan@gmail");
            var resultDelivery = deliverOrder.Deliver(ordersClient.Last());
            var orderDelivered = container.Resolve<IOrderReadOnlyRepository>().All.FirstOrDefault(c => c.Id == resultDelivery.Order.Id);
            Assert.IsTrue(orderDelivered.State == OrderState.Delivered);
        }

        [TestMethod]
        [ExpectedException(typeof(NotCompletedOrderException))]
        public void DeliverOrderNotComplete()
        {
            var container = new DependencyContainerMock();
            var deliverOrder = container.Resolve<IDeliverOrder>();
            var order = new Domain.Orders.Order() { State = OrderState.Error };
            deliverOrder.Deliver(order);
        }
    }
}