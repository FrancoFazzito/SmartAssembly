using Application.Computers.Commands.Build;
using Domain.Specification;
using System.Collections.Generic;

namespace Application.Repositories.Interfaces
{
    public interface ITypeUseReadOnlyRepository
    {
        ISpecification GetByUse(string use);

        IEnumerable<ISpecification> All { get; }
    }
}