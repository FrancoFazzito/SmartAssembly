using Domain.Clients;
using Domain.Computers;
using Domain.Employees;
using Domain.Orders.States;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Domain.Orders
{
    public class Order
    {
        private const int BUILD_COST = 500;

        public void Add(Computer computer, int quantity)
        {
            for (var i = 0; i < quantity; i++)
            {
                Computers.Add(computer);
            }

        }

        public void Remove(Computer computer)
        {
            Computers.Remove(computer);
        }

        public int Id { get; set; }
        public decimal Price => Computers.Sum(c => c.Price) + (Computers.Count * BUILD_COST);
        public DateTime OrderDate { get; set; }
        public DateTime OrderDelivery => OrderDate.AddDays(Computers.Count);
        public Employee Employee { get; set; }
        public ICollection<Computer> Computers { get; set; } = new List<Computer>();
        public Client Client { get; set; }
        public string Commentary { get; set; }
        public OrderState State { get; set; }
    }
}
