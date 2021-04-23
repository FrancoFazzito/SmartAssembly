using Application.Repositories.Interfaces;
using Domain.Computers;
using Domain.Importance;

namespace Application.Computers.Commands.Build
{
    public class ComputerRequest : IComputerRequest
    {
        public ComputerRequest(string use, decimal? budget, Importance importance, ITypeUseReadOnlyRepository repo)
        {
            Specification = repo.GetByUse(use);
            Budget = budget;
            Importance = importance;
        }

        public decimal? Budget { get; }
        public Importance Importance { get; }
        public ISpecification Specification { get; }
    }
}