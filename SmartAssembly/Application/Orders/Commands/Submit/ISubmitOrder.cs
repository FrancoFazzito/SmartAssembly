using Domain.Computers;

namespace Application.Orders.Commands.Submit
{
    public interface ISubmitOrder
    {
        void Add(Computer computerDto, int quantity);
        void Remove(Computer computerDto);
        SubmitOrderResult Submit(string email, string commentary);
    }
}