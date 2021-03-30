using Application.Computers.Commands.Build.Directors;
using Application.Computers.Commands.Build.Requests;
using Application.Repositories.TypeUses.Interfaces;
using Domain.Computers;
using Domain.Importance;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

namespace Tests
{
    [TestClass]
    public class BuildComputerTest
    {
        [TestMethod]
        public void BuildComputer()
        {
            var container = new DependencyContainerMock();
            var request = new ComputerRequest(TypeUse.gaming, 1200000, Importance.Price, container.Resolve<ITypeUseReadOnlyRepository>());
            var director = container.Resolve<IDirectorComputer>();
            var result = director.Build(request);
            var computers = result.Computers;
            Assert.IsTrue(computers.Count() > 0);
        }

        [TestMethod]
        [ExpectedException(typeof(NotAvailableComputersException))]
        public void BuildComputerWithouthCorrectPrice()
        {
            var container = new DependencyContainerMock();
            var request = new ComputerRequest(TypeUse.gaming, 0, Importance.Price, container.Resolve<ITypeUseReadOnlyRepository>());
            var director = container.Resolve<IDirectorComputer>();
            director.Build(request);
        }
    }
}
