using Domain.Computers;
using Domain.Orders;
using System.Collections.Generic;

namespace Application.Commands.RegisterOrderErrors
{
    public interface IRegisterOrderError
    {
        IEnumerable<Order> GetOrdersDeliveredByClient(string email);
        void Register(Computer computer, string commentary);
    }
}