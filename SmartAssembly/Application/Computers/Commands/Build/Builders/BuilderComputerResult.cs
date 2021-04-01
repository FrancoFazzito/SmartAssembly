using Domain.Computers;
using System.Collections.Generic;
using System.Linq;

namespace Application.Computers.Commands.Build.Builders
{
    public class BuilderComputerResult
    {
        public BuilderComputerResult(IEnumerable<Computer> computers)
        {
            Computers = computers.OrderByDescending(c => c.PricePerfomance);
        }

        public IEnumerable<Computer> Computers { get; }
    }
}