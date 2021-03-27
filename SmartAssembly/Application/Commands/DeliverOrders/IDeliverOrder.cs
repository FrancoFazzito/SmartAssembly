using Domain.Orders;
using System.Collections.Generic;

namespace Application.Commands.DeliverOrders
{
    public interface IDeliverOrder
    {
        DeliverResult Deliver(Order order);
        IEnumerable<Order> GetOrdersByClient(string emailClient);
    }
}