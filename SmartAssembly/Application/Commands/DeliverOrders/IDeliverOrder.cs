using Domain.Orders;
using System.Collections.Generic;

namespace Application.Commands.DeliverOrders
{
    public interface IDeliverOrder
    {
        DeliverResult Deliver(Order order);
        IEnumerable<Order> GetOrdersToDeliverByClient(string emailClient);
    }
}