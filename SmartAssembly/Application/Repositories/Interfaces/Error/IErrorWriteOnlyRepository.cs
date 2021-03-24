using Domain.Components;
using Domain.Computers;
using Domain.Orders.States;

namespace Application.Repositories.Interfaces.Error
{
    public interface IErrorWriteOnlyRepository
    {
        void InsertWithReplace(Component componentWithError, Component componentToReplace, Computer computer, string commentary, OrderState newStateOrder, bool deleteComponentError);
        void InsertWithouthReplace(Component componentWithError, Computer computer, string commentary, OrderState newStateOrder, bool deleteComponentError);
    }
}
