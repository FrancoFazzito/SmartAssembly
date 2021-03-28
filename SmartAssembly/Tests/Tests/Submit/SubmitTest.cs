﻿using Application.Commands.BuildComputers.Builders;
using Application.Commands.BuildComputers.Directors;
using Application.Commands.BuildComputers.Importances;
using Application.Commands.BuildComputers.Orders;
using Application.Commands.BuildComputers.Request;
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
    public class SubmitTest
    {

        [TestMethod]
        public void SubmitOrder()
        {
            var container = new DependencyContainerMock();
            var oldCount = container.Resolve<IOrderReadOnlyRepository>().All.Count();
            var request = new ComputerRequest(TypeUse.gaming, 1200000, Importance.Price, container.Resolve<ITypeUseReadOnlyRepository>());
            var director = container.Resolve<IDirectorComputer>();
            var resultDirector = director.Build(request);
            var computer = resultDirector.Computers.ElementAt(0);
            var submitOrder = container.Resolve<ISubmitOrder>();
            submitOrder.Add(computer, 3);
            submitOrder.Submit("juan@gmail", "comentario de prueba");
            var newCount = container.Resolve<IOrderReadOnlyRepository>().All.Count();
            var lastOrder = container.Resolve<IOrderReadOnlyRepository>().All.Last();
            Assert.IsTrue((newCount - oldCount) == 1 && lastOrder.State == OrderState.Uncompleted);
        }

        [TestMethod]
        [ExpectedException(typeof(ErrorStockException))]
        public void SubmitOrderWithoutStock()
        {
            var container = new DependencyContainerMock();
            var request = new ComputerRequest(TypeUse.gaming, 1200000, Importance.Price, container.Resolve<ITypeUseReadOnlyRepository>());
            var director = container.Resolve<IDirectorComputer>();
            var resultDirector = director.Build(request);
            var computer = resultDirector.Computers.ElementAt(0);
            var submitOrder = container.Resolve<ISubmitOrder>();
            submitOrder.Add(computer, 1000);
        }
    }
}