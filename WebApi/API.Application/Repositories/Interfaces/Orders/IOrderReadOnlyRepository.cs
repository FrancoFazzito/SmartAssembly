using Domain.Orders;
using System.Collections.Generic;

namespace Application.Repositories.Interfaces
{
    public interface IOrderReadOnlyRepository
    {
        IEnumerable<Order> All { get; }

        Order GetById(int id);
    }
}