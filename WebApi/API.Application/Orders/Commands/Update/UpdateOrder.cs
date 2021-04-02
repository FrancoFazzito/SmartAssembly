using Application.Repositories.Interfaces;
using Domain.Orders;

namespace Application.Orders.Commands.Update
{
    public class UpdateOrder
    {
        private readonly IUpdate<Order> update;

        public UpdateOrder(IUpdate<Order> update)
        {
            this.update = update;
        }

        public void Update(Order order)
        {
            update.Update(order);
        }
    }
}