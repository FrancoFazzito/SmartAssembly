﻿using Application.Repositories.Employees.Interfaces;
using Application.Repositories.Interfaces.Clients;
using Application.Repositories.Interfaces.Computers;
using Application.Repositories.Orders.Interfaces;
using Domain.Computers;
using Domain.Orders;
using Domain.Orders.States;

namespace Application.Commands.BuildComputers.Orders
{
    public class SubmitOrder : ISubmirOrder
    {
        public SubmitOrder(ISubmitOrderRepository repository, IEmployeeReadOnlyRepository employeeRepository, IClientReadOnlyRepository clientRepository, IComputerStockRepository computerStock)
        {
            Order = new Order();
            OrderRepository = repository;
            EmployeeRepository = employeeRepository;
            ClientRepository = clientRepository;
            ComputerStock = computerStock;
        }

        public void Add(Computer computer, int quantity)
        {
            if (ComputerStock.isValidStock(computer, quantity))
            {
                Order.Add(computer, quantity);
            }
            else
            {
                throw new ErrorComputerStockException(quantity);
            }
        }

        public void Remove(Computer computer)
        {
            Order.Remove(computer);
        }

        public Order Submit(string clientEmail, string commentary)
        {
            Order.OrderDate = System.DateTime.Now;
            Order.Client = ClientRepository.GetByName(clientEmail);
            Order.Commentary = commentary;
            var employee = EmployeeRepository.GetEmployeeWithoutOrder();
            Order.Employee = employee ?? EmployeeRepository.GetMostInactiveEmployee();
            Order.State = OrderState.Uncompleted;
            OrderRepository.Insert(Order);
            return Order;
        }

        public ISubmitOrderRepository OrderRepository { get; }
        public IEmployeeReadOnlyRepository EmployeeRepository { get; }
        public IClientReadOnlyRepository ClientRepository { get; }
        public IComputerStockRepository ComputerStock { get; }
        public Order Order { get; }
    }
}
