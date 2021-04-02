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

        public RegisterErrorOrderDelivered(IErrorOrderWriteOnlyRepository errorComputerRepository, IOrderReadOnlyRepository orderRepository)
        {
            this.errorComputerRepository = errorComputerRepository;
            this.orderRepository = orderRepository;
        }

        public void Register(Computer computer, string commentary)
        {
            errorComputerRepository.Insert(computer, commentary, OrderState.Error);
        }

        public IEnumerable<Order> GetOrdersDeliveredByClient(string email)
        {
            return orderRepository.All.Where(c => c.Client.Email == email)
                                      .Where(c => c.State == OrderState.Delivered);
        }
    }
}