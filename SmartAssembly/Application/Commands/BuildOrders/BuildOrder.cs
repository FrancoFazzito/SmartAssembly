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
        public BuildOrder(IBuildOrderRepository buildRepository, IOrderReadOnlyRepository orderRepository)
        {
            BuildRepository = buildRepository;
            OrderRepository = orderRepository;
        }

        public IBuildOrderRepository BuildRepository { get; }
        public IOrderReadOnlyRepository OrderRepository { get; }
        public string NameEmployee { get; private set; }

        public BuilderOrderResult Build(Order orderToBuild)
        {
            orderToBuild.State = OrderState.Completed;
            BuildRepository.Build(orderToBuild);
            return new BuilderOrderResult(orderToBuild, DateTime.Now, orderToBuild.Employee);
        }

        public IEnumerable<Order> GetOrdersByEmployee(string email)
        {
            return OrderRepository.All.Where(c => c.Employee.Email == email)
                                      .Where(c => c.State == OrderState.Uncompleted ||
                                                  c.State == OrderState.Error);
        }
    }
}
