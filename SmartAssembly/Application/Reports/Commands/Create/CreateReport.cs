using Application.Repositories.Orders.Interfaces;
using Domain.Orders;
using Domain.Orders.States;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Application.Reports.Commands.Create
{
    public class CreateReport : ICreateReport
    {
        private readonly IOrderReadOnlyRepository orderRepository;

        public CreateReport(IOrderReadOnlyRepository orderRepository)
        {
            this.orderRepository = orderRepository;
        }

        public IEnumerable<Order> OrdersRequested { get; private set; }
        public IEnumerable<KeyValuePair<string, int>> MostRequestedComponents => ComponentsOrderByMostRequested(OrdersRequested);
        public IEnumerable<Order> OrdersWithError => OrdersRequested.Where(o => o.State == OrderState.Error);
        public IEnumerable<Order> OrdersDelivered => OrdersRequested.Where(o => o.State == OrderState.Delivered);

        public void Create(DateTime since, DateTime until)
        {
            OrdersRequested = orderRepository.All.Where(o => Between(since, until, o.DateRequested));
        }

        private IEnumerable<KeyValuePair<string, int>> ComponentsOrderByMostRequested(IEnumerable<Order> orders)
        {
            return orders.SelectMany(o => o.Computers.SelectMany(c => c.Components))
                         .GroupBy(c => c.Name)
                         .ToDictionary(c => c.Key, c => c.Count())
                         .OrderByDescending(c => c.Value);
        }

        private bool Between(DateTime since, DateTime until, DateTime date)
        {
            return date >= since && date <= until;
        }
    }
}