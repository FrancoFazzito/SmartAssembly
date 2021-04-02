using Domain.Computers;

namespace Application.Repositories.Interfaces
{
    public interface IComputerStockRepository
    {
        bool IsValid(Computer computer, int quantity);
    }
}