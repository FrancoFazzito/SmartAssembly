using Application.Commands.BuildComputers.Builders;
using Application.Commands.BuildComputers.Importances;
using Application.Commands.BuildComputers.Request;

namespace Application.Commands.BuildComputers.Directors
{
    public interface IDirectorComputer
    {
        IBuilderComputer Builder { get; }
        BuilderComputerResult Build(IComputerRequest request);
    }
}
