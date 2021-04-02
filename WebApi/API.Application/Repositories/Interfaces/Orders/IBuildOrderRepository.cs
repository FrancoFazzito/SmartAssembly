using Domain.Orders;

namespace Application.Repositories.Interfaces
{
    public interface IBuildOrderRepository
    {
        void Build(Order orderToBuild);
    }
}