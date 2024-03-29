﻿using Domain.Components;
using Domain.Orders;
using System.Collections.Generic;

namespace Application.Orders.Commands.Create
{
    public class SubmitResult
    {
        public SubmitResult(IEnumerable<Component> componentsLowStock, Order order)
        {
            ComponentsLowStock = componentsLowStock;
            Order = order;
        }

        public Order Order { get; }
        public IEnumerable<Component> ComponentsLowStock { get; }
    }
}