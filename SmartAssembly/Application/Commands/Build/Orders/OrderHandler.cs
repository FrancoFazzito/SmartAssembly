using Application.Repositories.Employees.Interfaces;
using Application.Repositories.Orders.Interfaces;
using Domain.Clients;
using Domain.Computers;
using Domain.Orders;

namespace Application.Commands.Build.Orders
{
    public class OrderHandler : IOrderHandler
    {
        public OrderHandler(IOrderWriteOnlyRepository repository, IEmployeeReadOnlyRepository employeeRepository)
        {
            Order = new Order();
            OrderRepository = repository;
            EmployeeRepository = employeeRepository;
        }

        public void Add(Computer computer, int quantity)
        {
            Order.Add(computer, quantity);
        }

        public void Remove(Computer computer)
        {
            Order.Remove(computer);
        }

        public void Submit(Client client)
        {
            Order.OrderDate = System.DateTime.Now;
            Order.Client = client;
            var employee = EmployeeRepository.EmployeeWithoutOrder;
            Order.Employee = employee ?? EmployeeRepository.MostInactiveEmployee;
            OrderRepository.Insert(Order);
        }

        public IOrderWriteOnlyRepository OrderRepository { get; }
        public IEmployeeReadOnlyRepository EmployeeRepository { get; }
        public Order Order { get; }
    }


}
