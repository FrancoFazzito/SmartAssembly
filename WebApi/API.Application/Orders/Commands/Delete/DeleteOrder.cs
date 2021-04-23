using Application.Common.Exceptions;
using Application.Orders.Commands.Create;
using Application.Repositories.Interfaces;

namespace Application.Orders.Commands.Delete
{
    public class DeleteOrder
    {
        private readonly IDeleteById delete;
        private readonly IOrderReadOnlyRepository read;

        public DeleteOrder(IDeleteById delete, IOrderReadOnlyRepository read)
        {
            this.delete = delete;
            this.read = read;
        }

        public void Delete(int? id)
        {
            if (read.GetById(id) == null)
            {
                throw new NotFoundOrderException();
            }

            delete.Delete(id);
        }
    }
}