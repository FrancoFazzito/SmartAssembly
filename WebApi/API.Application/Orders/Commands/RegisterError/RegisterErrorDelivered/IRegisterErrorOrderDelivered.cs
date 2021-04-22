using Domain.Orders;
using System.Collections.Generic;

namespace Application.Orders.Commands.RegisterError
{
    public interface IRegisterErrorOrderDelivered
    {
        IEnumerable<Order> GetOrdersDeliveredByClient(string email);

        void Register(int? id, string commentary);
    }
}