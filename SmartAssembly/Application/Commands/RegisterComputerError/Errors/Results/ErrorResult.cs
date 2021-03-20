using Domain.Components;
using Domain.Computers;
using System;

namespace Application.Commands.RegisterComputerError.Errors.Results
{
    public class ErrorResult : IErrorResult
    {
        public ErrorResult(Component oldComponent, Component newComponent, Computer computer)
        {
            NameOldComponent = oldComponent.Name;
            NameNewComponent = newComponent.Name;
            PriceDiference = newComponent.Price - oldComponent.Price;
            Computer = computer;
            DateError = DateTime.Now;
        }

        public string NameOldComponent { get; }
        public string NameNewComponent { get; }
        public decimal PriceDiference { get; }
        public DateTime DateError { get; }
        public Computer Computer { get; }
    }
}
