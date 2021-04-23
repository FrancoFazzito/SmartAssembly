using Application.Common.Exceptions;
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
        private readonly int buildCost;
        private readonly int pricePerfomanceMultiplier;
        private readonly IStrategyOrderBy orderBy;
        private readonly IFactoryCompatibility factoryCompatibility;
        private readonly IFactoryEnough factoryEnough;
        private readonly IComponentReadOnlyRepository repository;

        public BuilderComputer(IStrategyOrderBy orderBy, IFactoryCompatibility factoryCompatibility, IFactoryEnough factoryEnough, IComponentReadOnlyRepository componentRepo, ICostsReadOnlyRepository costRepo)
        {
            this.orderBy = orderBy;
            this.factoryCompatibility = factoryCompatibility;
            this.factoryEnough = factoryEnough;
            repository = componentRepo;
            buildCost = costRepo.BuildCost;
            pricePerfomanceMultiplier = costRepo.PricePerfomanceMultiplier;
        }

        public IEnumerable<Component> GetComponents(IComputerRequest request)
        {
            this.request = request;
            components = orderBy.GetOrderedComponents(repository.All, request.Importance);
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
            if (!Cpu.IsCompatibleWith(factoryCompatibility[Compatibility.IntegratedVideo], Mother))
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
            if (Cpu.IsEnough(factoryEnough[Enough.MultipleRam], request.Specification.Ram))
            {
                Add(components.Where(c => c.IsType(TypePart.ram))
                              .Where(c => c.IsCompatibleWith(factoryCompatibility[Compatibility.Ram], Cpu))
                              .FirstOrDefault(c => c.IsEnough(factoryEnough[Enough.Capacity], request.Specification.Ram / Cpu.Channels)), Cpu.Channels);
                return;
            }

            Add(components.FirstOrDefault(c => c.IsEnough(factoryEnough[Enough.Capacity], request.Specification.Ram)));
        }

        public void AddTower()
        {
            Add(components.Where(c => c.IsType(TypePart.tower))
                                       .Where(c => c.IsCompatibleWith(factoryCompatibility[Compatibility.CaseFan], Fan))
                                       .FirstOrDefault(c => c.IsCompatibleWith(factoryCompatibility[Compatibility.CaseMother], Mother)));
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
            return InvalidComponent(component) || InvalidStock(component, quantity) || InvalidBudget(component);
        }

        private bool InvalidBudget(Component component)
        {
            return Computer.Price + component.Price >= request.Budget;
        }

        private static bool InvalidComponent(Component component)
        {
            return component == null;
        }

        private bool InvalidStock(Component component, int quantity)
        {
            return !component.IsEnough(factoryEnough[Enough.Stock], quantity);
        }

        private void ThrowInvalidAdd()
        {
            SetComputer();
            throw new InvalidAddException();
        }

        private void SetComputer()
        {
            Computer = new Computer()
            {
                TypeUse = request.Specification.TypeUse,
                CostBuild = buildCost,
                Multiplier = pricePerfomanceMultiplier
            };
        }

        public Computer Computer { get; private set; }
        private Component Cpu => Computer[TypePart.cpu];
        private Component Mother => Computer[TypePart.mother];
        private Component Fan => Computer[TypePart.fan];
    }
}