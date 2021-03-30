using Domain.Importance;

namespace Application.Commands.BuildComputers
{
    public interface IComputerRequest
    {
        decimal Budget { get; }
        ISpecification Specification { get; }
        Importance Importance { get; }
    }
}