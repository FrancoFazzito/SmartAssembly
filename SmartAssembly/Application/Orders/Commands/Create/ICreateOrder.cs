using Domain.Computers;

namespace Application.Orders.Commands.Create
{
    public interface ICreateOrder
    {
        void Add(Computer computer, int quantity);

        void Remove(Computer computer);

        CreateOrderResult Submit(string clientEmail, string commentary);
    }
}