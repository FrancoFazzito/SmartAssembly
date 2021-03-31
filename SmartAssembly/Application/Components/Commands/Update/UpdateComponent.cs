using Application.Repositories.Interfaces;
using Domain.Components;

namespace Application.Components.Commands.Update
{
    public class UpdateComponent
    {
        private readonly IUpdate<Component> update;

        public UpdateComponent(IUpdate<Component> update)
        {
            this.update = update;
        }

        public void Update(Component component)
        {
            update.Update(component);
        }
    }
}
