using Domain.Computers;
using Domain.Orders;

namespace Application.Orders.Commands.Create
{
    public interface ISubmitOrder
    {
        Order AddComputer(Order order, Computer computer, int? quantity);

        SubmitResult Submit(Order order, string clientEmail);
    }
}