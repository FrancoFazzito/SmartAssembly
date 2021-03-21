using Application.Repositories.Employees.Interfaces;
using Application.Repositories.Orders.Interfaces;
using Domain.Computers;

namespace Application.Commands.Build.Orders
{
    public interface IOrderHandler
    {
        void Add(Computer computerDto, int quantity);
        void Remove(Computer computerDto);
        void Submit(string email,string commentary);

        IOrderWriteOnlyRepository OrderRepository { get; }
        IEmployeeReadOnlyRepository EmployeeRepository { get; }
    }
}