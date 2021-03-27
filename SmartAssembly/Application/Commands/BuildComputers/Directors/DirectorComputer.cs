using Application.Commands.BuildComputers.Builders;
using Domain.Components;
using Domain.Components.Types;
using Domain.Computers;
using System.Collections.Generic;
using System.Linq;

namespace Application.Commands.BuildComputers.Directors
{
    public class DirectorComputer : IDirectorComputer
    {
        public DirectorComputer(IBuilder builder)
        {
            Builder = builder;
        }

        public BuilderComputerResult Build()
        {
            var computersBuilded = ComputersBuilded;
            return computersBuilded.Count() == 0 ? throw new NotAvailableComputersException() : new BuilderComputerResult(computersBuilded);
        }

        private IEnumerable<Computer> ComputersBuilded => from item in Builder.Components.Where(c => c.IsType(TypePart.cpu))
                                                          let computer = BuildComputer(item)
                                                          where computer != null
                                                          select computer;

        public Computer BuildComputer(Component root)
        {
            try
            {
                Builder.AddCpu(root);
                Builder.AddMother();
                Builder.AddRam();
                Builder.AddFan();
                Builder.AddGpu();
                Builder.AddHardDiskHDD();
                Builder.AddHardDiskSSD();
                Builder.AddTower();
                Builder.AddPsu();
                return Builder.Computer;
            }
            catch (InvalidAddException)
            {
                return null;
            }
        }

        public IBuilder Builder { get; }
    }
}
