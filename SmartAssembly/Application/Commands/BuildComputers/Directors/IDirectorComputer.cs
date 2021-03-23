using Application.Commands.BuildComputers.Builders;

namespace Application.Commands.BuildComputers.Directors
{
    public interface IDirectorComputer
    {
        IBuilder Builder { get; }
        BuilderComputerResult Build();
    }
}
