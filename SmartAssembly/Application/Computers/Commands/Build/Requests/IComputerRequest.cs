using Application.Computers.Commands.Build.Specification;
using Domain.Importance;

namespace Application.Computers.Commands.Build.Requests
{
    public interface IComputerRequest
    {
        decimal Budget { get; }
        ISpecification Specification { get; }
        Importance Importance { get; }
    }
}