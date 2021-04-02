using Domain.Computers;

namespace Application.Computers.Commands.Build
{
    public interface ISpecification
    {
        TypeUse TypeUse { get; }
        int Cpu { get; }
        int Mother { get; }
        int Fan { get; }
        int Ram { get; }
        int Gpu { get; }
        int Hdd { get; }
        int Ssd { get; }
    }
}