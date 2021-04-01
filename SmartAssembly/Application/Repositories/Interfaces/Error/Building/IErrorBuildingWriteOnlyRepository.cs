using Domain.Components;
using Domain.Computers;
using Domain.Orders.States;

namespace Application.Repositories.Interfaces.Error
{
    public interface IErrorBuildingWriteOnlyRepository
    {
        void Insert(Component componentWithError, Computer computer, string commentary, OrderState newStateOrder, bool deleteComponentError);
    }
}