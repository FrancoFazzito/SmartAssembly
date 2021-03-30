using Application.Commands.BuildComputers.Specifications;
using Domain.Importance;

namespace Application.Commands.BuildComputers.Request
{
    public interface IComputerRequest
    {
        decimal Budget { get; }
        ISpecification Specification { get; }
        Importance Importance { get; }
    }
}