using Application.Commands.BuildComputers.Specifications;
using Domain.Computers;

namespace Application.Repositories.TypeUses.Interfaces
{
    public interface ITypeUseReadOnlyRepository
    {
        ISpecification GetByUse(TypeUse use);
    }
}
