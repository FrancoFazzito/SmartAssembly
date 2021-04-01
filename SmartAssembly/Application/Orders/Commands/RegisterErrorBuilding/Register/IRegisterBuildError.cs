using Application.Orders.Commands.Register.RegisterErrorBuilding.Results;
using Domain.Components;
using Domain.Computers;

namespace Application.Orders.Commands.Register.RegisterErrorBuilding
{
    public interface IRegisterBuildError
    {
        IErrorResult Register(Computer computer, Component componentWithError, string commentary, bool deleteComponentWithError);
    }
}