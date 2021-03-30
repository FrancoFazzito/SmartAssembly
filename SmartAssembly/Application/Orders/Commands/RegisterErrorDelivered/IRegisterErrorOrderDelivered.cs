using Domain.Computers;
using Domain.Orders;
using System.Collections.Generic;

namespace Application.Orders.Commands.RegisterErrorOrderDelivered
{
    public interface IRegisterErrorOrderDelivered
    {
        IEnumerable<Order> GetOrdersDeliveredByClient(string email);
        void Register(Computer computer, string commentary);
    }
}