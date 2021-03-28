﻿using Application.Commands.BuildComputers.Builders;
using Application.Commands.BuildComputers.Directors;
using Application.Commands.BuildComputers.Importances;
using Application.Commands.BuildComputers.Request;
using Application.Factories.Compatibilities;
using Application.Factories.Enoughs;
using Application.Repositories.Components.Interfaces;
using Application.Repositories.TypeUses.Interfaces;
using Application.Strategies.OrderBy;
using Domain.Computers;
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