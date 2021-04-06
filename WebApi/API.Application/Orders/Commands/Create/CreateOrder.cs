using Application.Components.Commands.ControlStock;
using Application.Repositories.Interfaces;
using Domain.Clients;
using Domain.Computers;
using Domain.Employees;
using Domain.Orders;
using Domain.Orders.States;

namespace Application.Orders.Commands.Create
{
    public class CreateOrder : ICreateOrder
    {
        private readonly Order order;
        private readonly ISubmitOrderRepository orderRepository;
        private readonly IEmployeeReadOnlyRepository employeeRepository;
        private readonly IClientReadOnlyRepository clientRepository;
        private readonly IComputerStockRepository computerStock;
        private readonly IControlStock controlStock;

        public CreateOrder(ISubmitOrderRepository repository, IEmployeeReadOnlyRepository employeeRepository, IClientReadOnlyRepository clientRepository, IComputerStockRepository computerStock, IControlStock controlStock)
        {
            order = new Order();
            orderRepository = repository;
            this.employeeRepository = employeeRepository;
            this.clientRepository = clientRepository;
            this.computerStock = computerStock;
            this.controlStock = controlStock;
        }

        public Order Add(Computer computer, int quantity)
        {
            if (!computerStock.IsValid(computer, quantity))
            {
                throw new AddStockException(quantity);
            }

            order.Add(computer, quantity);
            return order;
        }

        public Order Remove(Computer computer)
        {
            order.Remove(computer);
            return order;
        }

        public CreateOrderResult Submit(Order order, string clientEmail)
        {
            order.DateRequested = System.DateTime.Now;
            order.State = OrderState.Uncompleted;
            order.Client = GetClient(clientEmail);
            order.Employee = GetEmployeeMostInactive();
            orderRepository.Insert(order);
            return new CreateOrderResult(controlStock.ComponentsLowStock, order);
        }

        private Client GetClient(string clientEmail)
        {
            return clientRepository.GetByEmail(clientEmail) ?? throw new NotExistClientException();
        }

        private Employee GetEmployeeMostInactive()
        {
            return employeeRepository.GetEmployeeWithoutOrder() ?? employeeRepository.GetMostInactiveEmployee();
        }
    }
}