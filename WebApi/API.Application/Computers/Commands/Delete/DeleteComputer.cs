using Application.Orders.Commands.RegisterError;
using Application.Repositories.Interfaces;

namespace Application.Computers.Commands.Delete
{
    public class DeleteComputer
    {
        private readonly IDeleteById delete;
        private readonly IComputerReadOnlyRepository read;

        public DeleteComputer(IDeleteById delete, IComputerReadOnlyRepository read)
        {
            this.delete = delete;
            this.read = read;
        }

        public void Delete(int? id)
        {
            if (read.GetById(id) == null)
            {
                throw new NotFoundComputerException();
            }

            delete.Delete(id);
        }
    }
}