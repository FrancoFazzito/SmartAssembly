using Application.Commands.ControlStock;
using Application.Repositories.Employees.Interfaces;
using Application.Repositories.Interfaces.Clients;
using Application.Repositories.Interfaces.Computers;
using Application.Repositories.Orders.Interfaces;
using Domain.Computers;
using Domain.Orders;
using Domain.Orders.States;

namespace Application.Commands.BuildComputers.Orders
{
    public class SubmitOrder : ISubmitOrder
    {
        private readonly Order order;
        private readonly ISubmitOrderRepository orderRepository;
        private readonly IEmployeeReadOnlyRepository employeeRepository;
        private readonly IClientReadOnlyRepository clientRepository;
        private readonly IComputerStockRepository computerStock;
        private readonly IControlStock controlStock;

        public SubmitOrder(ISubmitOrderRepository repository, IEmployeeReadOnlyRepository employeeRepository, IClientReadOnlyRepository clientRepository, IComputerStockRepository computerStock, IControlStock controlStock)
        {
            order = new Order();
            orderRepository = repository;
            this.employeeRepository = employeeRepository;
            this.clientRepository = clientRepository;
            this.computerStock = computerStock;
            this.controlStock = controlStock;
        }

        public void Add(Computer computer, int quantity)
        {
            if (!computerStock.IsValid(computer, quantity))
            {
                throw new ErrorStockException(quantity);
            }
            order.Add(computer, quantity);
        }

        public void Remove(Computer computer)
        {
            order.Remove(computer);
        }

        public SubmitOrderResult Submit(string clientEmail, string commentary)
        {
            PopulateOrder(clientEmail, commentary);
            orderRepository.Insert(order);
            return new SubmitOrderResult(controlStock.ComponentsLowStock, order);
        }

        private void PopulateOrder(string clientEmail, string commentary)
        {
            order.DateRequested = System.DateTime.Now;
            order.Client = clientRepository.GetByEmail(clientEmail);
            order.Commentary = commentary;
            order.State = OrderState.Uncompleted;
            var employee = employeeRepository.GetEmployeeWithoutOrder();
            order.Employee = employee ?? employeeRepository.GetMostInactiveEmployee();
        }
    }
}
