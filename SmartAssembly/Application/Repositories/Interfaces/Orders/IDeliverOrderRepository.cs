using Domain.Orders;

namespace Application.Repositories.Interfaces.Orders
{
    public interface IDeliverOrderRepository
    {
        void Deliver(Order order);
    }
}
