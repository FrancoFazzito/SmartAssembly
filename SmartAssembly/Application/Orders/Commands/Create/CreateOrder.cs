using Application.Components.Commands.ControlStock;
using Application.Repositories.Interfaces;
using Domain.Computers;
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

        public void Add(Computer computer, int quantity)
        {
            if (!computerStock.IsValid(computer, quantity))
            {
                throw new AddStockException(quantity);
            }

            order.Add(computer, quantity);
        }

        public void Remove(Computer computer)
        {
            order.Remove(computer);
        }

        public CreateOrderResult Submit(string clientEmail, string commentary)
        {
            if (clientRepository.GetByEmail(clientEmail) == null)
            {
                throw new NotExistClientException();
            }

            PopulateOrder(clientEmail, commentary);
            orderRepository.Insert(order);
            return new CreateOrderResult(controlStock.ComponentsLowStock, order);
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