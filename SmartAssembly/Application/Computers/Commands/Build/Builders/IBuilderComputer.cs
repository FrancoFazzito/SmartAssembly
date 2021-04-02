using Domain.Components;
using Domain.Computers;
using System.Collections.Generic;

namespace Application.Computers.Commands.Build
{
    public interface IBuilderComputer
    {
        Computer Computer { get; }

        void AddCpu(Component root);

        void AddFan();

        void AddGpu();

        void AddHardDiskHDD();

        void AddHardDiskSSD();

        void AddMother();

        void AddRam();

        void AddTower();

        void AddPsu();

        IEnumerable<Component> GetComponentsRoot(IComputerRequest request);
    }
}