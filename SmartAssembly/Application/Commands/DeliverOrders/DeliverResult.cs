using Domain.Orders;

namespace Application.Commands.DeliverOrders
{
    public class DeliverResult
    {
        public DeliverResult(Order order)
        {
            this.Order = order;
        }

        public Order Order { get; }
    }
}