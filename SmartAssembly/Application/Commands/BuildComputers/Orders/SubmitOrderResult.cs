using Domain.Components;
using Domain.Orders;
using System.Collections.Generic;

namespace Application.Commands.BuildComputers.Orders
{
    public class SubmitOrderResult
    {
        public SubmitOrderResult(IEnumerable<Component> componentsLowStock, Order order)
        {
            ComponentsLowStock = componentsLowStock;
            Order = order;
        }

        public Order Order { get; }
        public IEnumerable<Component> ComponentsLowStock { get; }
    }
}