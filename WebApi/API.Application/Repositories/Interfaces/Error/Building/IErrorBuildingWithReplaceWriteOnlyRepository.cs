using Domain.Components;
using Domain.Computers;
using Domain.Orders.States;

namespace Application.Repositories.Interfaces
{
    public interface IErrorBuildingWithReplaceWriteOnlyRepository
    {
        void Insert(Component componentWithError, Component componentToReplace, Computer computer, string commentary, OrderState newStateOrder, bool deleteComponentError);
    }
}