using Application.Common.Exceptions;
using Domain.Components;
using Domain.Computers;
using System.Collections.Generic;
using System.Linq;

namespace Application.Computers.Commands.Build
{
    public class DirectorComputer : IDirectorComputer
    {
        public DirectorComputer(IBuilderComputer builder)
        {
            Builder = builder;
        }

        public BuilderComputerResult Build(IComputerRequest request)
        {
            var computersBuilded = ComputersBuilded(request).ToList();
            return computersBuilded.Any() ? new BuilderComputerResult(computersBuilded) : throw new NotAvailableComputersException();
        }

        private IEnumerable<Computer> ComputersBuilded(IComputerRequest request)
        {
            return from cpu in Builder.GetComponents(request)
                   let computer = BuildComputer(cpu)
                   where computer != null
                   select computer;
        }

        public Computer BuildComputer(Component cpu)
        {
            try
            {
                Builder.AddCpu(cpu);
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
                //log
                return null;
            }
        }

        public IBuilderComputer Builder { get; }
    }
}