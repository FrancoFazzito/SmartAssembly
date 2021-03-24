using Application.Commands.RegisterComputerError.Errors.Results;
using Domain.Components;

namespace Application.Commands.RegisterComputerError.Errors
{
    public interface IRegisterError
    {
        IErrorResult Register(Component componentWithError, string commentary, bool deleteComponentWithError);
    }
}