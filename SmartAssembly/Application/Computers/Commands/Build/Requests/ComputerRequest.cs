using Application.Computers.Commands.Build.Specification;
using Application.Repositories.TypeUses.Interfaces;
using Domain.Computers;
using Domain.Importance;

namespace Application.Computers.Commands.Build.Requests
{
    public class ComputerRequest : IComputerRequest
    {
        public ComputerRequest(TypeUse use, decimal budget, Importance importance, ITypeUseReadOnlyRepository repo)
        {
            Specification = repo.GetByUse(use);
            Budget = budget;
            Importance = importance;
        }

        public decimal Budget { get; }
        public Importance Importance { get; }
        public ISpecification Specification { get; }
    }
}
