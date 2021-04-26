using Application.Common.Exceptions;
using Application.Repositories.Interfaces;
using Domain.Specification;

namespace Application.TypeUse.Commands.Create
{
    public class CreateTypeUse
    {
        private readonly ICreate<ISpecification> create;
        private readonly ITypeUseReadOnlyRepository read;

        public CreateTypeUse(ICreate<ISpecification> create, ITypeUseReadOnlyRepository read)
        {
            this.create = create;
            this.read = read;
        }

        public void Create(ISpecification specification)
        {
            if (read.GetByUse(specification.Name) != null)
            {
                throw new SpecificationAlreadyExistsException();
            }
            create.Create(specification);
        }
    }
}
