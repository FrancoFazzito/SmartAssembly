using Application.Orders.Commands.Build;
using Application.Repositories.Interfaces;
using Domain.Computers;
using Domain.Orders;
using Domain.Orders.States;
using System.Collections.Generic;
using System.Linq;

namespace Application.Orders.Commands.RegisterError
{
    public class RegisterErrorOrderDelivered : IRegisterErrorOrderDelivered
    {
        private readonly IErrorOrderWriteOnlyRepository errorComputerRepository;
        private readonly IOrderReadOnlyRepository orderRepository;
        private readonly IComputerReadOnlyRepository computerRepository;

        public RegisterErrorOrderDelivered(IErrorOrderWriteOnlyRepository errorComputerRepository, IOrderReadOnlyRepository orderRepository, IComputerReadOnlyRepository computerRepository)
        {
            this.errorComputerRepository = errorComputerRepository;
            this.orderRepository = orderRepository;
            this.computerRepository = computerRepository;
        }

        public void Register(int? id, string commentary)
        {
            var computer = GetComputer(id);
            errorComputerRepository.Insert(computer, commentary, OrderState.Error);
        }

        private Computer GetComputer(int? id)
        {
            return computerRepository.GetById(id) ?? throw new NotFoundComputerException();
        }

        public IEnumerable<Order> GetOrdersDeliveredByClient(string email)
        {
            var orders = orderRepository.All.Where(c => c.Client.Email == email)
                                        .Where(c => c.State == OrderState.Delivered);
            return orders.Any() ? orders : throw new NotAvailableOrdersException();
        }
    }
}