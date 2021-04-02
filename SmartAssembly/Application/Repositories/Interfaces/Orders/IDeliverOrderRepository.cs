using Domain.Orders;

namespace Application.Repositories.Interfaces
{
    public interface IDeliverOrderRepository
    {
        void Deliver(Order orderToDeliver);
    }
}