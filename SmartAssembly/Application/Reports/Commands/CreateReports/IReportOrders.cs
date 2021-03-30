using Domain.Orders;
using System;
using System.Collections.Generic;

namespace Application.Reports.Commands.CreateReports
{
    public interface IReportOrders
    {
        Dictionary<string, int> MostRequestedComponents { get; }
        IEnumerable<Order> OrdersRequested { get; }
        IEnumerable<Order> OrdersWithError { get; }
        IEnumerable<Order> OrdersDelivered { get; }

        void Create(DateTime since, DateTime until);
    }
}