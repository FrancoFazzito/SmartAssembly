using Application.Commands.BuildComputers.Directors;
using Application.Commands.BuildComputers.Importances;
using Application.Commands.BuildComputers.Orders;
using Application.Commands.BuildComputers.Request;
using Application.Commands.RegisterBuildError.Errors;
using Application.Repositories.Employees.Interfaces;
using Application.Repositories.Interfaces.Clients;
using Application.Repositories.Interfaces.Computers;
using Application.Repositories.Orders.Interfaces;
using Application.Repositories.TypeUses.Interfaces;
using Domain.Computers;
using Domain.Orders.States;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

namespace Tests
{
    [TestClass]
    public class SubmitErrorBuildTest
    {
        [TestMethod]
        public void SubmitError()
        {
            var container = new DependencyContainerMock();
            var request = new ComputerRequest(TypeUse.gaming, 1200000, Importance.Price, container.Resolve<ITypeUseReadOnlyRepository>());
            var director = container.Resolve<IDirectorComputer>();
            var resultDirector = director.Build(request);
            var computer = resultDirector.Computers.ElementAt(0);
            var submitOrder = container.Resolve<ISubmitOrder>();
            submitOrder.Add(computer, 1);
            submitOrder.Submit("juan@gmail", "comentario de prueba");

            var lastOrder = container.Resolve<IOrderReadOnlyRepository>().All.Last();
            var registerError = container.Resolve<IRegisterBuildError>();
            var errorResult = registerError.Register(lastOrder.Computers.ElementAt(0), computer.Components.ElementAt(0), "error de prueba", false);
            var OrderWithError = container.Resolve<IOrderReadOnlyRepository>().All.Last();

            Assert.IsTrue(OrderWithError.State == OrderState.Error && errorResult != null);
        }
    }
}
