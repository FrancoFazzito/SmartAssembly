using Domain.Components;
using System;

namespace Application.Commands.RegisterComputerError.Errors.Results
{
    public class ErrorWithoutReplaceResult : IErrorResult
    {
        public ErrorWithoutReplaceResult(Component oldComponent, string commentary)
        {
            DateError = DateTime.Now;
            OldComponent = oldComponent;
            Commentary = commentary;
        }

        public decimal DifferencePrice => 0 - OldComponent.Price;
        public DateTime DateError { get; }
        public Component OldComponent { get; }
        public Component NewComponent => null;
        public string Commentary { get; }
    }
}
