using Application.Commands.Build.Builders;

namespace Application.Commands.Build.Directors
{
    public interface IDirectorComputer
    {
        IBuilder Builder { get; }
        BuilderComputerResult Build();
    }
}
