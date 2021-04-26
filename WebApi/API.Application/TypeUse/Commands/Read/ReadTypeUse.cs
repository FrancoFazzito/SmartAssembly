using Application.Computers.Commands.Build;
using Application.Repositories.Interfaces;
using Domain.Specification;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.TypeUse.Commands.Read
{
    public class ReadTypeUse
    {
        private readonly ITypeUseReadOnlyRepository read;

        public ReadTypeUse(ITypeUseReadOnlyRepository read)
        {
            this.read = read;
        }

        public IEnumerable<ISpecification> Read()
        {
            return read.All;
        }
    }
}
