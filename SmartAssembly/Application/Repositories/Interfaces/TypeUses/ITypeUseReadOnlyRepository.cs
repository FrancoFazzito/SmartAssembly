using Application.Commands.BuildComputers.Specifications;

namespace Application.Repositories.TypeUses.Interfaces
{
    public interface ITypeUseReadOnlyRepository
    {
        ISpecification GetByName(string use);
    }
}
