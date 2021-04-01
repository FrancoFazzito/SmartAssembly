using Domain.Computers;

namespace Application.Repositories.Interfaces.Computers
{
    public interface IComputerStockRepository
    {
        bool IsValid(Computer computer, int quantity);
    }
}