using Domain.Computers;
using Domain.Orders.States;

namespace Application.Repositories.Interfaces.Error
{
    public interface IErrorComputerWriteOnlyRepository
    {
        void Insert(Computer computer, string commentary, OrderState newState);
    }
}
