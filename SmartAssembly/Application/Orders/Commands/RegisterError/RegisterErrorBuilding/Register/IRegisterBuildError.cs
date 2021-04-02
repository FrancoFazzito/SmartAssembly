using Domain.Components;
using Domain.Computers;

namespace Application.Orders.Commands.RegisterError
{
    public interface IRegisterBuildError
    {
        IErrorResult Register(Computer computer, Component componentWithError, string commentary, bool deleteComponentWithError);
    }
}