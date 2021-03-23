using Domain.Orders;
using System.Collections.Generic;

namespace Application.Commands.BuildOrders
{
    public interface IBuilderOrder
    {
        BuilderOrderResult Build(Order orderToBuild);
        IEnumerable<Order> GetOrdersByEmployee(string email);
    }
}