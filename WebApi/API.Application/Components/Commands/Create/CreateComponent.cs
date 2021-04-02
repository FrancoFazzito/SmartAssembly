using Application.Repositories.Interfaces;
using Domain.Components;

namespace Application.Components.Commands.Create
{
    public class CreateComponent
    {
        private readonly ICreate<Component> create;

        public CreateComponent(ICreate<Component> create)
        {
            this.create = create;
        }

        public void Create(Component component)
        {
            create.Create(component);
        }
    }
}