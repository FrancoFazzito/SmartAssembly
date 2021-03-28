using Application.Commands.BuildComputers.Importances;
using Application.Commands.BuildComputers.Specifications;
using Application.Repositories.TypeUses.Interfaces;
using Domain.Computers;

namespace Application.Commands.BuildComputers.Request
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
