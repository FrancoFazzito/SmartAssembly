using Application.Repositories.Orders.Interfaces;
using Domain.Orders;
using Domain.Orders.States;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Application.Commands.CreateReports
{
    public class ReportOrders : IReportOrders
    {
        private readonly IOrderReadOnlyRepository orderRepository;

        public ReportOrders(IOrderReadOnlyRepository orderRepository)
        {
            this.orderRepository = orderRepository;
        }

        public IEnumerable<Order> OrdersRequested { get; private set; }
        public Dictionary<string, int> MostRequestedComponents => GetComponentsMostRequested(OrdersRequested);
        public IEnumerable<Order> OrdersWithError => OrdersRequested.Where(o => o.State == OrderState.Error);
        public IEnumerable<Order> OrdersDelivered => OrdersRequested.Where(o => o.State == OrderState.Delivered);

        public void Create(DateTime since, DateTime until)
        {
            OrdersRequested = orderRepository.All.Where(o => Between(since, until, o.DateRequested));
        }

        private Dictionary<string, int> GetComponentsMostRequested(IEnumerable<Order> orders)
        {
            var componentQuantity = new Dictionary<string, int>();

            foreach (var componentName in orders.SelectMany(order => order.Computers.SelectMany(computer => computer.Components.Select(c => c.Name))))
            {
                if (componentQuantity.ContainsKey(componentName))
                {
                    componentQuantity[componentName] += 1;
                }
                else
                {
                    componentQuantity.Add(componentName, 1);
                }
            }
            return componentQuantity.OrderByDescending(c => c.Value).Take(10).ToDictionary(c => c.Key, c => c.Value);
        }

        private bool Between(DateTime since, DateTime until, DateTime date)
        {
            return date >= since && date <= until;
        }
    }
}
