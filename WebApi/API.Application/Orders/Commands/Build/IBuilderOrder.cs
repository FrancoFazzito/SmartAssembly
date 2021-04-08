using Domain.Orders;
using System.Collections.Generic;

namespace Application.Orders.Commands.Build
{
    public interface IBuilderOrder
    {
        BuilderOrderResult Build(int? id);

        IEnumerable<Order> GetOrdersByEmployee(string email);
    }
}