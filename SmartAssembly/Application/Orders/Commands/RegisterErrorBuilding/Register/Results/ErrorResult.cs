using Domain.Components;

namespace Application.Orders.Commands.Register.RegisterErrorBuilding.Results
{
    public class ErrorResult : IErrorResult
    {
        private readonly Component oldComponent;
        private readonly Component newComponent;

        public ErrorResult(Component oldComponent, Component newComponent, string commentary)
        {
            this.oldComponent = oldComponent;
            this.newComponent = newComponent;
            Commentary = commentary;
        }

        public decimal PriceDifference => newComponent.Price - oldComponent.Price;
        public string NewComponent => newComponent.Name;
        public string OldComponent => oldComponent.Name;
        public string Commentary { get; }
    }
}