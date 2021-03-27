using Application.Commands.BuildComputers.Builders;
using Application.Commands.BuildComputers.Directors;
using Application.Commands.BuildComputers.Importances;
using Application.Commands.BuildComputers.Orders;
using Application.Commands.BuildComputers.Request;
using Application.Commands.BuildComputers.Specifications;
using Application.Commands.BuildOrders;
using Application.Commands.DeliverOrders;
using Application.Factories.Compatibilities;
using Application.Factories.Enoughs;
using Application.Repositories.Components.Interfaces;
using Application.Repositories.Employees.Interfaces;
using Application.Repositories.Interfaces.Clients;
using Application.Repositories.Interfaces.Computers;
using Application.Repositories.Interfaces.Orders;
using Application.Repositories.Orders.Interfaces;
using Application.Repositories.TypeUses.Interfaces;
using Application.Strategies.OrderBy;
using Domain.Orders.States;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

namespace Tests
{
    [TestClass]
    public class DeliveredTest
    {
        private const string ClientEmail = "juan@gmail";

        [TestMethod]
        public void DeliverOrder()
        {
            var container = new DependencyContainerMock();
            var computer = new DirectorComputer(new BuilderComputer(new ComputerRequest(TypeUse.gaming, 1200000, container.Resolve<ITypeUseReadOnlyRepository>()), Importance.Price, container.Resolve<IStrategyOrderBy>(), container.Resolve<IFactoryCompatibility>(), container.Resolve<IFactoryEnough>(), container.Resolve<IComponentReadOnlyRepository>())).Build().Computers.ElementAt(0);
            var repoComputerStock = container.Resolve<IComputerStockRepository>();
            var submitOrder = new SubmitOrder(container.Resolve<ISubmitOrderRepository>(), container.Resolve<IEmployeeReadOnlyRepository>(), container.Resolve<IClientReadOnlyRepository>(), repoComputerStock); //ver si poner un mediator en el medio para la application
            submitOrder.Add(computer, 3);
            var order = submitOrder.Submit(ClientEmail, "maincra 0");
            var builder = container.Resolve<IBuilderOrder>();
            order = builder.GetOrdersByEmployee(order.Employee.Email).Last();
            builder.Build(order);

            DeliverOrder deliverOrder = new DeliverOrder(container.Resolve<IOrderReadOnlyRepository>(),container.Resolve<IDeliverOrderRepository>());
            var ordersClient = deliverOrder.GetOrdersByClient(ClientEmail);
            var resultDelivery = deliverOrder.Deliver(ordersClient.Last());
            var orderDelivered = container.Resolve<IOrderReadOnlyRepository>().All.FirstOrDefault(c => c.Id == resultDelivery.Order.Id);
            Assert.IsTrue(orderDelivered.State == OrderState.Delivered);
        }

        [TestMethod]
        [ExpectedException(typeof(NotCompletedOrderException))]
        public void DeliverOrderNotComplete()
        {
            var container = new DependencyContainerMock();
            DeliverOrder deliverOrder = new DeliverOrder(container.Resolve<IOrderReadOnlyRepository>(),container.Resolve<IDeliverOrderRepository>());
            deliverOrder.Deliver(new Domain.Orders.Order(){ State = OrderState.Mistake });
        }
    }
}
