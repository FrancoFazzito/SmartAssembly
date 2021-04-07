using Domain.Computers;
using Domain.Orders;

namespace Application.Orders.Commands.Create
{
    public interface ISubmitOrder
    {
        SubmitResult Submit(Order order, string clientEmail);
    }
}