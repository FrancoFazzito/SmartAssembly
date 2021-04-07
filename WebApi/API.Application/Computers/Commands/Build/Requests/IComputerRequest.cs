using Domain.Importance;

namespace Application.Computers.Commands.Build
{
    public interface IComputerRequest
    {
        decimal? Budget { get; }
        ISpecification Specification { get; }
        Importance Importance { get; }
    }
}