using Domain.Orders;

namespace Application.Repositories.Interfaces
{
    public interface ISubmitOrderRepository
    {
        void Insert(Order order);
    }
}