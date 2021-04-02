using Domain.Components;

namespace Application.Orders.Commands.RegisterError
{
    public class ErrorWithouthReplaceResult : IErrorResult
    {
        private readonly Component oldComponent;

        public ErrorWithouthReplaceResult(Component oldComponent, string commentary)
        {
            this.oldComponent = oldComponent;
            Commentary = commentary;
        }

        public decimal PriceDifference => 0 - oldComponent.Price;
        public string NewComponent => "";
        public string OldComponent => oldComponent.Name;
        public string Commentary { get; }
    }
}