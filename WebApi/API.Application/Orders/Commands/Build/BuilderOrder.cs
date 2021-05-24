using Application.Common.Exceptions;
using Application.Repositories.Interfaces;
using Domain.Orders;
using Domain.Orders.States;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Application.Orders.Commands.Build
{
    public class BuilderOrder : IBuilderOrder
    {
        private readonly IBuildOrderRepository buildRepository;
        private readonly IOrderReadOnlyRepository orderRepository;

        public BuilderOrder(IBuildOrderRepository buildRepository, IOrderReadOnlyRepository orderRepository)
        {
            this.buildRepository = buildRepository;
            this.orderRepository = orderRepository;
        }

        public BuilderOrderResult Build(int? id)
        {
            var order = GetOrder(id);
            order.State = OrderState.Completed;
            buildRepository.Build(order);
            return new BuilderOrderResult(order, DateTime.Now, order.Employee);
        }

        private Order GetOrder(int? id)
        {
            return orderRepository.GetById(id) ?? throw new NotFoundOrderException();
        }

        public IEnumerable<Order> GetOrdersByEmployee(string email)
        {
            var orders = FilterCompletedComputers(orderRepository.GetByEmployee(email)
                                                                 .Where(order => order.State == OrderState.Uncompleted || order.State == OrderState.Error));

            return orders.Any() ? orders : throw new NotAvailableOrdersException();
        }

        private IEnumerable<Order> FilterCompletedComputers(IEnumerable<Order> orders)
        {
            foreach (var (order, computer) in orders.SelectMany(order => order.Computers.Where(computer => computer.Completed).Select(computer => (order, computer))))
            {
                order.Remove(computer);
            }
            return orders;
        }
    }
}