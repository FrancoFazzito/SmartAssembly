using Application.Repositories.Interfaces.Error;
using Application.Repositories.Orders.Interfaces;
using Domain.Computers;
using Domain.Orders;
using Domain.Orders.States;
using System.Collections.Generic;
using System.Linq;

namespace Application.Commands.RegisterOrderErrors
{
    public class RegisterOrderError : IRegisterOrderError
    {
        private readonly IErrorComputerWriteOnlyRepository errorComputerRepository;
        private readonly IOrderReadOnlyRepository orderRepository;

        public RegisterOrderError(IErrorComputerWriteOnlyRepository errorComputerRepository, IOrderReadOnlyRepository orderRepository)
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
