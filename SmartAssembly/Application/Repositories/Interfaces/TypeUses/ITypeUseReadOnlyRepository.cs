using Application.Commands.Build.Specifications;

namespace Application.Repositories.TypeUses.Interfaces
{
    public interface ITypeUseReadOnlyRepository
    {
        ISpecification GetByName(string use);
    }
}
