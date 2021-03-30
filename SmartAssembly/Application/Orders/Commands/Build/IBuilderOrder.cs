using Domain.Orders;
using System.Collections.Generic;

namespace Application.Orders.Commands.Build
{
    public interface IBuilderOrder
    {
        BuilderOrderResult Build(Order orderToBuild);
        IEnumerable<Order> GetOrdersByEmployee(string email);
    }
}