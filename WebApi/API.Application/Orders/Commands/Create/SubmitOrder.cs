﻿using Application.Components.Commands.ControlStock;
using Application.Repositories.Interfaces;
using Domain.Clients;
using Domain.Employees;
using Domain.Orders;
using Domain.Orders.States;

namespace Application.Orders.Commands.Create
{
    public class SubmitOrder : ISubmitOrder
    {
        private readonly ISubmitOrderRepository orderRepository;
        private readonly IEmployeeReadOnlyRepository employeeRepository;
        private readonly IClientReadOnlyRepository clientRepository;
        private readonly IComputerStockRepository computerStock;
        private readonly IComponentStock componentStock;
        private readonly IOrderReadOnlyRepository orderReadOnlyRepository;

        public SubmitOrder(ISubmitOrderRepository orderRepository, IEmployeeReadOnlyRepository employeeRepository, IClientReadOnlyRepository clientRepository, IComputerStockRepository computerStock, IComponentStock componentStock, IOrderReadOnlyRepository orderReadOnlyRepository)
        {
            this.orderRepository = orderRepository;
            this.employeeRepository = employeeRepository;
            this.clientRepository = clientRepository;
            this.computerStock = computerStock;
            this.componentStock = componentStock;
            this.orderReadOnlyRepository = orderReadOnlyRepository;
        }

        public SubmitResult Submit(Order order, string clientEmail)
        {
            CheckStock(order);
            order.DateRequested = System.DateTime.Now;
            order.State = OrderState.Uncompleted;
            order.Client = GetClient(clientEmail);
            order.Employee = GetEmployeeMostInactive();
            orderRepository.Insert(order);
            return new SubmitResult(componentStock.ComponentsLowStock, order);
        }

        private void CheckStock(Order order)
        {
            if (!computerStock.IsValid(order.Computers))
            {
                throw new AddStockException(order.Computers.Count);
            }
        }

        private Client GetClient(string clientEmail)
        {
            return clientRepository.GetByEmail(clientEmail) ?? throw new NotExistClientException();
        }

        private Employee GetEmployeeMostInactive()
        {
            return employeeRepository.GetEmployeeWithoutOrder() ?? employeeRepository.GetMostInactiveEmployee();
        }
    }
}