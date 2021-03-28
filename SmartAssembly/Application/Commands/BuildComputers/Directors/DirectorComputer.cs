﻿using Application.Commands.BuildComputers.Builders;
using Application.Commands.BuildComputers.Importances;
using Application.Commands.BuildComputers.Request;
using Domain.Components;
using Domain.Components.Types;
using Domain.Computers;
using System.Collections.Generic;
using System.Linq;

namespace Application.Commands.BuildComputers.Directors
{
    public class DirectorComputer : IDirectorComputer
    {
        public DirectorComputer(IBuilderComputer builder)
        {
            Builder = builder;
        }

        public BuilderComputerResult Build(IComputerRequest request)
        {
            var computersBuilded = ComputersBuilded(request);
            return computersBuilded.Count() == 0 ? throw new NotAvailableComputersException() : new BuilderComputerResult(computersBuilded);
        }

        private IEnumerable<Computer> ComputersBuilded(IComputerRequest request)
        {
            return from cpu in Builder.ComponentsRoot(request)
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