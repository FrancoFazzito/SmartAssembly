using Domain.Orders;
using System.Collections.Generic;

namespace Application.Orders.Commands.Deliver
{
    public interface IDeliverOrder
    {
        DeliverResult Deliver(Order order);

        IEnumerable<Order> GetOrdersToDeliverByClient(string emailClient);
    }
}