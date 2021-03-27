using Domain.Computers;
using System.Collections.Generic;

namespace Application.Repositories.Interfaces.Computers
{
    public interface IComputerReadOnlyRepository
    {
        IEnumerable<Computer> GetByOrder(int id);
    }
}
