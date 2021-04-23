using Application.Repositories.Interfaces;
using Domain.Orders;
using System.Collections.Generic;

namespace Application.Orders.Commands.Read
{
    public class ReadOrder
    {
        private readonly IOrderReadOnlyRepository read;

        public ReadOrder(IOrderReadOnlyRepository read)
        {
            this.read = read;
        }

        public IEnumerable<Order> All => read.All;
    }
}
