using Application.Commands.BuildComputers;
using Domain.Computers;

namespace Application.Repositories.TypeUses.Interfaces
{
    public interface ITypeUseReadOnlyRepository
    {
        ISpecification GetByUse(TypeUse use);
    }
}
