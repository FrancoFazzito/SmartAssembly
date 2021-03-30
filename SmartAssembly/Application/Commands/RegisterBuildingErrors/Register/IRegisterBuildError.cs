using Application.Commands.RegisterBuildingError.Errors.Results;
using Domain.Components;
using Domain.Computers;

namespace Application.Commands.RegisterBuildingError
{
    public interface IRegisterBuildError
    {
        IErrorResult Register(Computer computer, Component componentWithError, string commentary, bool deleteComponentWithError);
    }
}