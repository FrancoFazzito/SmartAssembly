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
            var orders = orderRepository.All
                                  .Where(order => order.Employee.Email == email)
                                  .Where(order => order.State == OrderState.Uncompleted || order.State == OrderState.Error)
                                  .Select(order => new Order()
                                  {
                                      Client = order.Client,
                                      Commentary = order.Commentary,
                                      Computers = order.Computers.Where(c => !c.Completed).ToList(),
                                      DateDelivered = order.DateDelivered,
                                      DateRequested = order.DateRequested,
                                      Employee = order.Employee,
                                      Id = order.Id,
                                      State = order.State
                                  });

            return orders.Any() ? orders : throw new NotAvailableOrdersException();
        }
    }
}