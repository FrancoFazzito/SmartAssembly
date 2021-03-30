using Application.Commands.BuildComputers.Directors;
using Application.Commands.BuildComputers.Request;
using Application.Commands.EditCongifuration;
using Application.Repositories.TypeUses.Interfaces;
using Domain.Computers;
using Domain.Importance;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Configuration;
using System.Linq;

namespace Tests
{
    [TestClass]
    public class EditConfigurationTest
    {
        [TestMethod]
        public void BuildComputer()
        {
            var container = new DependencyContainerMock();
            int newcost = 5000;
            int newMultiplier = 7000;
            var editor = container.Resolve<IConfigurationEditor>();
            var oldCost = int.Parse(ConfigurationManager.AppSettings["BUILD_COST"]);
            var oldMultiplier = int.Parse(ConfigurationManager.AppSettings["PRICE_PERFOMANCE_MULTIPLIER"]);
            editor.EditCostBuild(newcost);
            editor.EditPricePerfomanceMultiplier(newMultiplier);
            var editedCost = int.Parse(ConfigurationManager.AppSettings["BUILD_COST"]) == newcost;
            var editerMultiplier = int.Parse(ConfigurationManager.AppSettings["PRICE_PERFOMANCE_MULTIPLIER"]) == newMultiplier;
            Assert.IsTrue(editedCost && editerMultiplier);
            editor.EditCostBuild(oldCost);
            editor.EditPricePerfomanceMultiplier(oldMultiplier);
        }
    }
}
