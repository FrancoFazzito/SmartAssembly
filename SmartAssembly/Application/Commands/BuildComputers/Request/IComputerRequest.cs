using Application.Commands.BuildComputers.Specifications;

namespace Application.Commands.BuildComputers.Request
{
    public interface IComputerRequest
    {
        decimal Budget { get; }
        ISpecification Specification { get; }
    }
}