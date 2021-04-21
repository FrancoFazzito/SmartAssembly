using Application.Orders.Commands.RegisterError;
using Application.Repositories.Interfaces;

namespace Application.Components.Commands.Delete
{
    public class DeleteComponent
    {
        private readonly IDeleteById delete;
        private readonly IComponentReadOnlyRepository read;

        public DeleteComponent(IDeleteById delete, IComponentReadOnlyRepository read)
        {
            this.delete = delete;
            this.read = read;
        }

        public void Delete(int? id)
        {
            if (read.GetById(id) == null)
            {
                throw new NotFoundComponentException();
            }
            delete.Delete(id);
        }
    }
}