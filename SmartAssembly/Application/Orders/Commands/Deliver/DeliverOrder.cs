using Application.Repositories.Interfaces;
using Domain.Orders;
using Domain.Orders.States;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Application.Orders.Commands.Deliver
{
    public class DeliverOrder : IDeliverOrder
    {
        private readonly IOrderReadOnlyRepository orderRepository;
        private readonly IDeliverOrderRepository deliverRepository;

        public DeliverOrder(IOrderReadOnlyRepository orderRepository, IDeliverOrderRepository deliverRepository)
        {
            this.orderRepository = orderRepository;
            this.deliverRepository = deliverRepository;
        }

        public DeliverResult Deliver(Order order)
        {
            if (order.State == OrderState.Completed)
            {
                order.State = OrderState.Delivered;
                order.DateDelivered = DateTime.Now;
                deliverRepository.Deliver(order);
                return new DeliverResult(order);
            }
            throw new NotCompletedOrderException();
        }

        public IEnumerable<Order> GetOrdersToDeliverByClient(string emailClient)
        {
            return orderRepository.All.Where(c => c.Client.Email == emailClient)
                                      .Where(c => c.State == OrderState.Completed);
        }
    }
}