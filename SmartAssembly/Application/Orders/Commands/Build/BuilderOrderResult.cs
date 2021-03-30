using Domain.Employees;
using Domain.Orders;
using System;

namespace Application.Commands.BuildOrders
{
    public class BuilderOrderResult
    {
        public BuilderOrderResult(Order orderToBuild, DateTime date, Employee employee)
        {
            OrderBuilded = orderToBuild;
            Date = date;
            Employee = employee;
        }

        public Order OrderBuilded { get; }
        public DateTime Date { get; }
        public Employee Employee { get; }
    }
}
