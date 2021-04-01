using Application.Repositories.Interfaces;
using Domain.Orders;

namespace Application.Orders.Commands.Delete
{
    public class DeleteOrder
    {
        private readonly IDelete<Order> delete;

        public DeleteOrder(IDelete<Order> delete)
        {
            this.delete = delete;
        }

        public void Delete(int id)
        {
            delete.Delete(id);
        }
    }
}