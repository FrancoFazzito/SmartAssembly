using Domain.Orders;
using System;
using System.Collections.Generic;

namespace Application.Reports.Commands.Create
{
    public interface ICreateReport
    {
        IEnumerable<KeyValuePair<string, int>> MostRequestedComponents { get; }
        IEnumerable<Order> OrdersRequested { get; }
        IEnumerable<Order> OrdersWithError { get; }
        IEnumerable<Order> OrdersDelivered { get; }

        void Create(DateTime since, DateTime until);
    }
}