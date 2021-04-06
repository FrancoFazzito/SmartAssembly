using Domain.Computers;
using Domain.Orders;

namespace Application.Orders.Commands.Create
{
    public interface ICreateOrder
    {
        Order Add(Computer computer, int quantity);

        Order Remove(Computer computer);

        CreateOrderResult Submit(Order order, string clientEmail);
    }
}