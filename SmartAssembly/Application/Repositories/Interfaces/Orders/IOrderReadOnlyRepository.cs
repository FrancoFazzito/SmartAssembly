using Domain.Orders;
using System.Collections.Generic;

namespace Application.Repositories.Orders.Interfaces
{
    public interface IOrderReadOnlyRepository
    {
        IEnumerable<Order> All { get; }
    }
}

