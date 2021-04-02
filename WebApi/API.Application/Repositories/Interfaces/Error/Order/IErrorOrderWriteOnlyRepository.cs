using Domain.Computers;
using Domain.Orders.States;

namespace Application.Repositories.Interfaces
{
    public interface IErrorOrderWriteOnlyRepository
    {
        void Insert(Computer computer, string commentary, OrderState newState);
    }
}