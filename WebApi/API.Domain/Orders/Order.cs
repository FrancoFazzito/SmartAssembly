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
        private readonly ICollection<Computer> computers = new List<Computer>();

        public void Add(Computer computer, int? quantity = 1)
        {
            for (var i = 0; i < quantity; i++)
            {
                computers.Add(computer);
            }
        }

        public void Remove(Computer computer)
        {
            computers.Remove(computer);
        }

        public int Id { get; set; }
        public decimal Price => Computers.Sum(c => c.Price);
        public DateTime DateRequested { get; set; }
        public DateTime DateToDelivery => DateRequested.AddDays(computers.Count);
        public DateTime DateDelivered { get; set; }
        public Employee Employee { get; set; }
        public IEnumerable<Computer> Computers { get => computers; }
        public Client Client { get; set; }
        public string Commentary { get; set; }
        public OrderState State { get; set; }
    }
}