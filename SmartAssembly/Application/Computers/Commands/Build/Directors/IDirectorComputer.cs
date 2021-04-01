using Application.Computers.Commands.Build.Builders;
using Application.Computers.Commands.Build.Requests;

namespace Application.Computers.Commands.Build.Directors
{
    public interface IDirectorComputer
    {
        IBuilderComputer Builder { get; }

        BuilderComputerResult Build(IComputerRequest request);
    }
}