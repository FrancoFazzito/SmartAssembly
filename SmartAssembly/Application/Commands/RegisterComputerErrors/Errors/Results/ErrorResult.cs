using Domain.Components;
using System;

namespace Application.Commands.RegisterComputerError.Errors.Results
{
    public class ErrorResult : IErrorResult
    {
        public ErrorResult(Component oldComponent, Component newComponent, string commentary)
        {
            DateError = DateTime.Now;
            OldComponent = oldComponent;
            NewComponent = newComponent;
            Commentary = commentary;
        }

        public decimal DifferencePrice => NewComponent.Price - OldComponent.Price;
        public DateTime DateError { get; }
        public Component OldComponent { get; }
        public Component NewComponent { get; }
        public string Commentary { get; }
    }
}
