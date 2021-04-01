using Application.Computers.Commands.Build.Directors;
using Application.Computers.Commands.Build.Requests;
using Application.Orders.Commands.Build;
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
            var submitOrder = container.Resolve<ICreateOrder>();
            submitOrder.Add(computer, 3);
            var submitResult = submitOrder.Submit("juan@gmail", "comentario de prueba");

            var lastOrder = container.Resolve<IBuilderOrder>().GetOrdersByEmployee(submitResult.Order.Employee.Email).Last();
            var result = container.Resolve<IBuilderOrder>().Build(lastOrder);
            var orderBuilded = container.Resolve<IOrderReadOnlyRepository>().GetById(result.OrderBuilded.Id);
            Assert.IsTrue(orderBuilded.State == OrderState.Completed);
        }
    }
}