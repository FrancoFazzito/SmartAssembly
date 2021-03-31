using Application.Repositories.Interfaces;
using Domain.Components;

namespace Application.Components.Commands.Delete
{
    public class DeleteComponent
    {
        private readonly IDelete<Component> delete;

        public DeleteComponent(IDelete<Component> delete)
        {
            this.delete = delete;
        }

        public void Delete(int id)
        {
            delete.Delete(id);
        }
    }
}
