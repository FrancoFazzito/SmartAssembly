using Application.Computers.Commands.Build.Directors;
using Application.Computers.Commands.Build.Requests;
using Application.Orders.Commands.Register.RegisterErrorBuilding;
using Application.Orders.Commands.Submit;
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
            submitOrder.Add(computer, 3);
            submitOrder.Submit("juan@gmail", "comentario de prueba");

            var lastOrder = container.Resolve<IOrderReadOnlyRepository>().All.Last();
            var registerError = container.Resolve<IRegisterBuildError>();
            var errorResult = registerError.Register(lastOrder.Computers.ElementAt(0), computer.Components.ElementAt(0), "error de prueba", false);
            var OrderWithError = container.Resolve<IOrderReadOnlyRepository>().All.Last();

            Assert.IsTrue(OrderWithError.State == OrderState.Error && errorResult != null);
        }
    }
}
