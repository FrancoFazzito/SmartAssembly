using Application.Repositories.Interfaces;
using Domain.Components;

namespace Application.Components.Commands.Create
{
    public class CreateComponent
    {
        private readonly ICreate<Component> create;
        private readonly IComponentReadOnlyRepository read;

        public CreateComponent(ICreate<Component> create, IComponentReadOnlyRepository read)
        {
            this.create = create;
            this.read = read;
        }

        public void Create(Component component)
        {
            if (read.GetByName(component.Name) != null)
            {
                throw new ComponentNameAlreadyExistException();
            }

            create.Create(component);
        }
    }
}