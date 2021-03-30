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
        public decimal Price => Computers.Sum(c => c.Price);
        public DateTime DateRequested { get; set; }
        public DateTime DateToDelivery => DateRequested.AddDays(Computers.Count);
        public DateTime DateDelivered { get; set; }
        public Employee Employee { get; set; }
        public ICollection<Computer> Computers { get; set; } = new List<Computer>();
        public Client Client { get; set; }
        public string Commentary { get; set; }
        public OrderState State { get; set; }
    }
}
