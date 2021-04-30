using Domain.Orders;
using System.Collections.Generic;

namespace Application.Repositories.Interfaces
{
    public interface IOrderReadOnlyRepository
    {
        IEnumerable<Order> All { get; }

        IEnumerable<Order> GetByClient(string email);
        IEnumerable<Order> GetByEmployee(string email);
        Order GetById(int? id);
    }
}