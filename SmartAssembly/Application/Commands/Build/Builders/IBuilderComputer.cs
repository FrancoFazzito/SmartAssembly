using Application.Commands.Build.Request;
using Application.Factories.Compatibilities;
using Application.Factories.Enoughs;
using Domain.Components;
using Domain.Computers;
using System.Collections.Generic;

namespace Application.Commands.Build.Builders
{
    public interface IBuilder
    {
        Computer Computer { get; }
        IComputerRequest Request { get; }
        IFactoryCompatibility FactoryCompatibilty { get; }
        IFactoryEnough FactoryEnough { get; }
        IEnumerable<Component> Components { get; }
        void AddCpu(Component root);
        void AddFan();
        void AddGpu();
        void AddHardDiskHDD();
        void AddHardDiskSSD();
        void AddMother();
        void AddRam();
        void AddTower();
        void AddPsu();
    }
}
