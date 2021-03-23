using Domain.Orders;

namespace Application.Repositories.Orders.Interfaces
{
    public interface ISubmitOrderRepository
    {
        void Insert(Order order);
    }
}

