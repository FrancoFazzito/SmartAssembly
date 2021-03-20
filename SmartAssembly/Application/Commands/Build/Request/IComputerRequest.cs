using Application.Commands.Build.Specifications;

namespace Application.Commands.Build.Request
{
    public interface IComputerRequest
    {
        decimal Budget { get; }
        ISpecification Specification { get; }
    }
}