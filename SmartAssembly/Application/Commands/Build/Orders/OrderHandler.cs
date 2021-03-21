using Application.Repositories.Employees.Interfaces;
using Application.Repositories.Interfaces.Clients;
using Application.Repositories.Orders.Interfaces;
using Domain.Computers;
using Domain.Orders;

namespace Application.Commands.Build.Orders
{
    public class OrderHandler : IOrderHandler
    {
        public OrderHandler(IOrderWriteOnlyRepository repository, IEmployeeReadOnlyRepository employeeRepository, IClientReadOnlyRepository clientRepository)
        {
            Order = new Order();
            OrderRepository = repository;
            EmployeeRepository = employeeRepository;
            ClientRepository = clientRepository;
        }

        public void Add(Computer computer, int quantity)
        {
            Order.Add(computer, quantity);
        }

        public void Remove(Computer computer)
        {
            Order.Remove(computer);
        }

        public void Submit(string clientEmail, string commentary)
        {
            Order.OrderDate = System.DateTime.Now;
            Order.Client = ClientRepository.GetByName(clientEmail);
            Order.Commentary = commentary;
            var employee = EmployeeRepository.GetEmployeeWithoutOrder();
            Order.Employee = employee ?? EmployeeRepository.GetMostInactiveEmployee();
            OrderRepository.Insert(Order);
        }

        public IOrderWriteOnlyRepository OrderRepository { get; }
        public IEmployeeReadOnlyRepository EmployeeRepository { get; }
        public IClientReadOnlyRepository ClientRepository { get; }
        public Order Order { get; }
    }
}
