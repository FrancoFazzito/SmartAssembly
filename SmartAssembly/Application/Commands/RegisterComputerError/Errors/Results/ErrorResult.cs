using Domain.Components;
using Domain.Computers;
using System;

namespace Application.Commands.RegisterComputerError.Errors.Results
{
    public class ErrorResult : IErrorResult
    {
        public ErrorResult(Component oldComponent, Component newComponent, int idComputer, string commentary)
        {
            NameOldComponent = oldComponent.Name;
            NameNewComponent = newComponent.Name;
            PriceDiference = newComponent.Price - oldComponent.Price;
            DateError = DateTime.Now;
            IdComputer = idComputer;
            Commentary = commentary;
        }

        public int IdComputer { get; }
        public string Commentary { get; }
        public string NameOldComponent { get; }
        public string NameNewComponent { get; }
        public decimal PriceDiference { get; }
        public DateTime DateError { get; }
    }
}
