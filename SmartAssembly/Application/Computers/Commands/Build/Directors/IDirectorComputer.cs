namespace Application.Computers.Commands.Build
{
    public interface IDirectorComputer
    {
        IBuilderComputer Builder { get; }

        BuilderComputerResult Build(IComputerRequest request);
    }
}