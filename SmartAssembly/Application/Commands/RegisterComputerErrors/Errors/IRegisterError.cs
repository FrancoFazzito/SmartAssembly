using Application.Commands.RegisterComputerError.Errors.Results;
using Domain.Components;
using Domain.Computers;

namespace Application.Commands.RegisterComputerError.Errors
{
    public interface IRegisterError
    {
        IErrorResult Register(Computer computer, Component componentWithError, string commentary, bool deleteComponentWithError);
    }
}