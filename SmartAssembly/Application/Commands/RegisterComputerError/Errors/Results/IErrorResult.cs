using Domain.Computers;
using System;

namespace Application.Commands.RegisterComputerError.Errors.Results
{
    public interface IErrorResult
    {
        string NameOldComponent { get; }
        string NameNewComponent { get; }
        decimal PriceDiference { get; }
        DateTime DateError { get; }
        Computer Computer { get; }
    }
}