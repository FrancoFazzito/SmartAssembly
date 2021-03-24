using Domain.Components;
using System;

namespace Application.Commands.RegisterComputerError.Errors.Results
{
    public interface IErrorResult
    {
        decimal DifferencePrice { get; }
        DateTime DateError { get; }
        Component OldComponent { get; }
        Component NewComponent { get; }
        string Commentary { get; }
    }
}