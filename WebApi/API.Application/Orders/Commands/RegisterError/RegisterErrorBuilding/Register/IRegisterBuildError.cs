using Domain.Components;
using Domain.Computers;

namespace Application.Orders.Commands.RegisterError
{
    public interface IRegisterBuildError
    {
        IErrorResult Register(int? idComputer, int? idComponentWithError, string commentary, bool deleteComponentWithError);
    }
}