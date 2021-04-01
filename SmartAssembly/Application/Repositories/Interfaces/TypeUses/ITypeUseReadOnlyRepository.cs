using Application.Computers.Commands.Build.Specification;
using Domain.Computers;

namespace Application.Repositories.TypeUses.Interfaces
{
    public interface ITypeUseReadOnlyRepository
    {
        ISpecification GetByUse(TypeUse use);
    }
}