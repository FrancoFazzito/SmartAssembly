using Domain.Components;
using Domain.Computers;
using System;

namespace Application.Commands.RegisterComputerError.Errors.Results
{
    public class ErrorWithoutReplaceResult : IErrorResult
    {
        public ErrorWithoutReplaceResult(Component oldComponent, Computer computer)
        {
            NameOldComponent = oldComponent.Name;
            PriceDiference = 0 - oldComponent.Price;
            Computer = computer;
            DateError = DateTime.Now;
        }

        public string NameOldComponent { get; }
        public string NameNewComponent => "";
        public decimal PriceDiference { get; }
        public DateTime DateError { get; }
        public Computer Computer { get; }
    }
}
