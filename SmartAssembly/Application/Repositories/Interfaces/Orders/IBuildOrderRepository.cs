using Domain.Orders;

namespace Application.Repositories.Interfaces.Orders
{
    public interface IBuildOrderRepository
    {
        void Build(Order orderToBuild);
    }
}