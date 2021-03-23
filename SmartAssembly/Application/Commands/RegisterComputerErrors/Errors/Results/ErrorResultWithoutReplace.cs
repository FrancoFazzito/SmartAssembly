using Domain.Components;
using System;

namespace Application.Commands.RegisterComputerError.Errors.Results
{
    public class ErrorWithoutReplaceResult : IErrorResult
    {
        public ErrorWithoutReplaceResult(Component oldComponent, int idComputer, string commentary)
        {
            NameOldComponent = oldComponent.Name;
            PriceDiference = 0 - oldComponent.Price;
            DateError = DateTime.Now;
            IdComputer = idComputer;
            Commentary = commentary;
        }

        public int IdComputer { get; }
        public string Commentary { get; }
        public string NameOldComponent { get; }
        public string NameNewComponent => "";
        public decimal PriceDiference { get; }
        public DateTime DateError { get; }
    }
}
