using Domain.Orders;

namespace Application.Repositories.Orders.Interfaces
{
    public interface IOrderWriteOnlyRepository
    {
        void Insert(Order order);
    }
}

