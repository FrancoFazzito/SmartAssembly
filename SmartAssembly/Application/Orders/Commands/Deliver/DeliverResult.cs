using Domain.Orders;

namespace Application.Commands.DeliverOrders
{
    public class DeliverResult
    {
        public DeliverResult(Order order)
        {
            Order = order;
        }

        public Order Order { get; }
    }
}