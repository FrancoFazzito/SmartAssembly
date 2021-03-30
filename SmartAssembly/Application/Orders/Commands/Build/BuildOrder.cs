using Application.Repositories.Interfaces.Orders;
using Application.Repositories.Orders.Interfaces;
using Domain.Orders;
using Domain.Orders.States;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Application.Commands.BuildOrders
{
    public class BuildOrder : IBuilderOrder
    {
        private readonly IBuildOrderRepository buildRepository;
        private readonly IOrderReadOnlyRepository orderRepository;

        public BuildOrder(IBuildOrderRepository buildRepository, IOrderReadOnlyRepository orderRepository)
        {
            this.buildRepository = buildRepository;
            this.orderRepository = orderRepository;
        }

        public BuilderOrderResult Build(Order orderToBuild)
        {
            orderToBuild.State = OrderState.Completed;
            buildRepository.Build(orderToBuild);
            return new BuilderOrderResult(orderToBuild, DateTime.Now, orderToBuild.Employee);
        }

        public IEnumerable<Order> GetOrdersByEmployee(string email)
        {
            return orderRepository.All
                                  .Where(order => order.Employee.Email == email)
                                  .Where(order => order.State == OrderState.Uncompleted || order.State == OrderState.Error)
                                  .Select(order => new Order()
                                  {
                                      Client = order.Client,
                                      Commentary = order.Commentary,
                                      Computers = order.Computers.Where(c => c.Completed == false).ToList(),
                                      DateDelivered = order.DateDelivered,
                                      DateRequested = order.DateRequested,
                                      Employee = order.Employee,
                                      Id = order.Id,
                                      State = order.State
                                  });
        }
    }
}
