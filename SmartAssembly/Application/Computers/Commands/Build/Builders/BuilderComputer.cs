using Application.Common.Factories.Compatibilities;
using Application.Common.Factories.Enoughs;
using Application.Common.Strategies.OrderBy;
using Application.Repositories.Interfaces;
using Domain.Compatibility.Enums;
using Domain.Components;
using Domain.Components.Types;
using Domain.Computers;
using Domain.Enoughs.Enums;
using System.Collections.Generic;
using System.Linq;

namespace Application.Computers.Commands.Build
{
    public class BuilderComputer : IBuilderComputer
    {
        private IEnumerable<Component> components;
        private IComputerRequest request;
        private readonly IStrategyOrderBy orderBy;
        private readonly IFactoryCompatibility factoryCompatibility;
        private readonly IFactoryEnough factoryEnough;
        private readonly IComponentReadOnlyRepository repository;

        public BuilderComputer(IStrategyOrderBy orderBy, IFactoryCompatibility factoryCompatibility, IFactoryEnough factoryEnough, IComponentReadOnlyRepository repository)
        {
            this.orderBy = orderBy;
            this.factoryCompatibility = factoryCompatibility;
            this.factoryEnough = factoryEnough;
            this.repository = repository;
        }

        public IEnumerable<Component> GetComponentsRoot(IComputerRequest request)
        {
            components = orderBy.GetOrderedComponents(repository.All, request.Importance);
            this.request = request;
            return components.Where(c => c.IsType(TypePart.cpu));
        }

        public void AddCpu(Component root)
        {
            SetComputer();
            if (root.IsEnough(factoryEnough[Enough.Level], request.Specification.Cpu))
            {
                Add(root);
                return;
            }

            ThrowInvalidAdd();
        }

        public void AddFan()
        {
            if (Cpu.IsEnough(factoryEnough[Enough.Fan], request.Specification.Fan))
            {
                Add(components.Where(c => c.IsType(TypePart.fan))
                                           .Where(c => c.IsCompatibleWith(factoryCompatibility[Compatibility.Fan], Cpu))
                                           .FirstOrDefault(c => c.IsEnough(factoryEnough[Enough.Level], request.Specification.Fan)));
            }
        }

        public void AddGpu()
        {
            if (Cpu.IsEnough(factoryEnough[Enough.VideoLevel], request.Specification.Gpu))
            {
                Add(components.Where(c => c.IsType(TypePart.gpu))
                                           .FirstOrDefault(c => c.IsEnough(factoryEnough[Enough.Level], request.Specification.Gpu)));
                return;
            }
            CheckIntregatedVideo();
        }

        private void CheckIntregatedVideo()
        {
            if (!Computer[TypePart.cpu].IsCompatibleWith(factoryCompatibility[Compatibility.IntegratedVideo], Computer[TypePart.mother]))
            {
                ThrowInvalidAdd();
            }
        }

        public void AddHardDiskHDD()
        {
            Add(components.Where(c => c.IsType(TypePart.hdd))
                                       .FirstOrDefault(c => c.IsEnough(factoryEnough[Enough.Capacity], request.Specification.Hdd)));
        }

        public void AddHardDiskSSD()
        {
            Add(components.Where(c => c.IsType(TypePart.ssd))
                                       .FirstOrDefault(c => c.IsEnough(factoryEnough[Enough.Capacity], request.Specification.Ssd)));
        }

        public void AddMother()
        {
            Add(components.Where(c => c.IsType(TypePart.mother))
                                       .Where(c => c.IsCompatibleWith(factoryCompatibility[Compatibility.Mother], Cpu))
                                       .Where(c => c.IsEnough(factoryEnough[Enough.Channels], Cpu.Channels))
                                       .FirstOrDefault(c => c.IsEnough(factoryEnough[Enough.Level], request.Specification.Mother)));
        }

        public void AddRam()
        {
            if (Computer[TypePart.cpu].IsEnough(factoryEnough[Enough.MultipleRam], request.Specification.Ram))
            {
                var ram = components.Where(c => c.IsType(TypePart.ram))
                                                 .Where(c => c.IsCompatibleWith(factoryCompatibility[Compatibility.Ram], Cpu))
                                                 .FirstOrDefault(c => c.IsEnough(factoryEnough[Enough.Capacity], request.Specification.Ram / Cpu.Channels));
                Add(ram, Cpu.Channels);
                return;
            }

            Add(components.FirstOrDefault(c => c.IsEnough(factoryEnough[Enough.Capacity], request.Specification.Ram)));
        }

        public void AddTower()
        {
            Add(components.Where(c => c.IsType(TypePart.tower))
                                       .Where(c => c.IsCompatibleWith(factoryCompatibility[Compatibility.CaseFan], Computer[TypePart.fan]))
                                       .FirstOrDefault(c => c.IsCompatibleWith(factoryCompatibility[Compatibility.CaseMother], Computer[TypePart.mother])));
        }

        public void AddPsu()
        {
            Add(components.Where(c => c.IsType(TypePart.psu))
                                       .FirstOrDefault(c => c.IsEnough(factoryEnough[Enough.Capacity], Computer.TotalConsumption)));
        }

        private void Add(Component component, int quantity = 1)
        {
            if (InvalidComponent(component, quantity))
            {
                ThrowInvalidAdd();
            }

            Computer.Add(component, quantity);
        }

        private bool InvalidComponent(Component component, int quantity)
        {
            return CheckInvalidComponent(component, quantity) || CheckInvalidBudget(component);
        }

        private bool CheckInvalidBudget(Component component)
        {
            return Computer.Price + component.Price >= request.Budget;
        }

        private bool CheckInvalidComponent(Component component, int quantity)
        {
            return component == null || !component.IsEnough(factoryEnough[Enough.Stock], quantity);
        }

        private void ThrowInvalidAdd()
        {
            SetComputer();
            throw new InvalidAddException();
        }

        private void SetComputer()
        {
            Computer = new Computer
            {
                TypeUse = request.Specification.Use
            };
        }

        public Computer Computer { get; private set; }
        private Component Cpu => Computer[TypePart.cpu];
    }
}