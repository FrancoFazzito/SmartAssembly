using Application.Commands.BuildComputers.Specifications;
using Application.Repositories.TypeUses.Interfaces;

namespace Application.Commands.BuildComputers.Request
{
    public class ComputerRequest : IComputerRequest
    {
        public ComputerRequest(TypeUse use, decimal budget, ITypeUseReadOnlyRepository repo)
        {
            Specification = repo.GetByName(use.ToString());
            Budget = budget;
        }

        public decimal Budget { get; }
        public ISpecification Specification { get; }
    }
}
