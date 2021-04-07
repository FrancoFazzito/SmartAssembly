using Domain.Computers;
using System.Collections.Generic;

namespace Application.Repositories.Interfaces
{
    public interface IComputerStockRepository
    {
        bool IsValid(IEnumerable<Computer> computers);
    }
}