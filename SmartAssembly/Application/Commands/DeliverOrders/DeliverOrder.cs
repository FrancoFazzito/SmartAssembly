using Application.Repositories.Interfaces.Orders;
using Application.Repositories.Orders.Interfaces;
using Domain.Orders;
using Domain.Orders.States;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Application.Commands.DeliverOrders
{
    public class DeliverOrder : IDeliverOrder
    {
        public DeliverOrder(IOrderReadOnlyRepository orderRepository, IDeliverOrderRepository deliverRepository)
        {
            OrderRepository = orderRepository;
            DeliverRepository = deliverRepository;
        }

        public DeliverResult Deliver(Order order)
        {
            if (order.State == OrderState.Completed)
            {
                order.State = OrderState.Delivered;
                order.DateDelivered = DateTime.Now;
                DeliverRepository.Deliver(order);
                return new DeliverResult(order);
            }
            throw new NotCompletedOrderException();
        }

        public IEnumerable<Order> GetOrdersToDeliverByClient(string emailClient)
        {
            return OrderRepository.All.Where(c => c.Client.Email == emailClient)
                                      .Where(c => c.State == OrderState.Completed);
        }

        public IOrderReadOnlyRepository OrderRepository { get; }
        public IDeliverOrderRepository DeliverRepository { get; }
    }
}
