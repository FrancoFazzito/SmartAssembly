using Application.Computers.Commands.Build.Directors;
using Application.Computers.Commands.Build.Requests;
using Application.Orders.Commands.Build;
using Application.Orders.Commands.Create;
using Application.Orders.Commands.Deliver;
using Application.Reports.Commands.Create;
using Application.Repositories.TypeUses.Interfaces;
using Domain.Computers;
using Domain.Importance;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;

namespace Tests
{
    [TestClass]
    public class CreateReportTest
    {
        [TestMethod]
        public void CreateReport()
        {
            var container = new DependencyContainerMock();
            var request = new ComputerRequest(TypeUse.gaming, 1200000, Importance.Price, container.Resolve<ITypeUseReadOnlyRepository>());
            var director = container.Resolve<IDirectorComputer>();
            var resultDirector = director.Build(request);
            var computer = resultDirector.Computers.ElementAt(0);
            var submitOrder = container.Resolve<ICreateOrder>();
            submitOrder.Add(computer, 3);
            submitOrder.Submit("juan@gmail", "comentario de prueba");

            request = new ComputerRequest(TypeUse.gaming, 1200000, Importance.Price, container.Resolve<ITypeUseReadOnlyRepository>());
            director = container.Resolve<IDirectorComputer>();
            resultDirector = director.Build(request);
            computer = resultDirector.Computers.ElementAt(0);
            submitOrder = container.Resolve<ICreateOrder>();
            submitOrder.Add(computer, 3);
            var order = submitOrder.Submit("juan@gmail", "comentario de prueba").Order;

            var builder = container.Resolve<IBuilderOrder>();
            order = builder.GetOrdersByEmployee(order.Employee.Email).Last();
            builder.Build(order);

            var deliverOrder = container.Resolve<IDeliverOrder>();
            var ordersClient = deliverOrder.GetOrdersToDeliverByClient("juan@gmail");
            deliverOrder.Deliver(ordersClient.Last());

            var report = container.Resolve<ICreateReport>();
            report.Create(DateTime.Parse("1970/05/05"), DateTime.Now);
            foreach (var item in report.MostRequestedComponents)
            {
                Console.WriteLine(item.Key + " " + item.Value);
            }
            Assert.IsTrue(report.MostRequestedComponents.Count() == 10 && report.OrdersWithError.Any() && report.OrdersRequested.Any() && report.OrdersDelivered.Any());
        }
    }
}