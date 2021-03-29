using Application.Commands.RegisterBuildError.Errors.Results;
using Domain.Components;
using Domain.Computers;

namespace Application.Commands.RegisterBuildError.Errors
{
    public interface IRegisterBuildError
    {
        IErrorResult Register(Computer computer, Component componentWithError, string commentary, bool deleteComponentWithError);
    }
}