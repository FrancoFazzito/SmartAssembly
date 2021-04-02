using Application.Repositories.Interfaces;

namespace Application.Components.Commands.Delete
{
    public class DeleteComponent
    {
        private readonly IDeleteById delete;

        public DeleteComponent(IDeleteById delete)
        {
            this.delete = delete;
        }

        public void Delete(int id)
        {
            delete.Delete(id);
        }
    }
}