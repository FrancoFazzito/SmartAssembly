using Application.Repositories.Employees.Interfaces;
using Application.Repositories.Orders.Interfaces;
using Domain.Computers;
using Domain.Orders;

namespace Application.Commands.BuildComputers.Orders
{
    public interface ISubmirOrder
    {
        void Add(Computer computerDto, int quantity);
        void Remove(Computer computerDto);
        Order Submit(string email, string commentary);

        ISubmitOrderRepository OrderRepository { get; }
        IEmployeeReadOnlyRepository EmployeeRepository { get; }
    }
}