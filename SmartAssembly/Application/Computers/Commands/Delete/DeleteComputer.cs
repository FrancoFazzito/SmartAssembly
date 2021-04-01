using Application.Repositories.Interfaces;
using Domain.Computers;

namespace Application.Computers.Commands.Delete
{
    public class DeleteComputer
    {
        private readonly IDeleteById delete;

        public DeleteComputer(IDeleteById delete)
        {
            this.delete = delete;
        }

        public void Delete(int id)
        {
            delete.Delete(id);
        }
    }
}