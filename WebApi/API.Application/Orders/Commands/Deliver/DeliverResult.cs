using Domain.Orders;

namespace Application.Orders.Commands.Deliver
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