using Domain.Computers;

namespace Application.Repositories.Interfaces.Computers
{
    public interface IComputerStockRepository
    {
        bool isValidStock(Computer computer, int quantity);
    }
}
