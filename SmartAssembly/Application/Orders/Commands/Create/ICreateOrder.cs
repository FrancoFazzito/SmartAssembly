using Domain.Computers;

namespace Application.Orders.Commands.Create
{
    public interface ICreateOrder
    {
        void Add(Computer computerDto, int quantity);
        void Remove(Computer computerDto);
        CreateOrderResult Submit(string email, string commentary);
    }
}