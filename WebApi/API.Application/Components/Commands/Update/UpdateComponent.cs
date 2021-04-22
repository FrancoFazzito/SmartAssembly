using Application.Orders.Commands.RegisterError;
using Application.Repositories.Interfaces;
using Domain.Components;

namespace Application.Components.Commands.Update
{
    public class UpdateComponent
    {
        private readonly IUpdate<Component> update;
        private readonly IComponentReadOnlyRepository read;

        public UpdateComponent(IUpdate<Component> update, IComponentReadOnlyRepository read)
        {
            this.update = update;
            this.read = read;
        }

        public void Update(int? id, Component component)
        {
            if (read.GetById(id) == null)
            {
                throw new NotFoundComponentException();
            }
            update.Update(component);
        }
    }
}