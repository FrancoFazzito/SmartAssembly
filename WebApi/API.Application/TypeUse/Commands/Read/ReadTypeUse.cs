using Application.Repositories.Interfaces;
using Domain.Specification;
using System.Collections.Generic;

namespace Application.TypeUse.Commands.Read
{
    public class ReadTypeUse
    {
        private readonly ITypeUseReadOnlyRepository read;

        public ReadTypeUse(ITypeUseReadOnlyRepository read)
        {
            this.read = read;
        }

        public IEnumerable<ISpecification> All => read.All;
    }
}
