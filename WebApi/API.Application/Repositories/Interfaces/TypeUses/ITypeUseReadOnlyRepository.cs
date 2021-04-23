using Application.Computers.Commands.Build;
using Domain.Computers;

namespace Application.Repositories.Interfaces
{
    public interface ITypeUseReadOnlyRepository
    {
        ISpecification GetByUse(string use);
    }
}