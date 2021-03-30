namespace Application.Commands.BuildComputers
{
    public interface IDirectorComputer
    {
        IBuilderComputer Builder { get; }
        BuilderComputerResult Build(IComputerRequest request);
    }
}
