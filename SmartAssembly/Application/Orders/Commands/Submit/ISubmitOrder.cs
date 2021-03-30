using Domain.Computers;

namespace Application.Commands.BuildComputers
{
    public interface ISubmitOrder
    {
        void Add(Computer computerDto, int quantity);
        void Remove(Computer computerDto);
        SubmitOrderResult Submit(string email, string commentary);
    }
}