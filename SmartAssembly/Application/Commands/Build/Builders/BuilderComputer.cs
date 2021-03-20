using Application.Commands.Build.Importances;
using Application.Commands.Build.Request;
using Application.Exceptions.Add;
using Application.Factories.Compatibilities;
using Application.Factories.Enoughs;
using Application.Repositories.Components.Interfaces;
using Application.Strategies.OrderBy;
using Domain.Compatibility.Enums;
using Domain.Components;
using Domain.Components.Types;
using Domain.Computers;
using Domain.Enoughs.Enums;
using System.Collections.Generic;
using System.Linq;

namespace Application.Commands.Build.Builders
{
    public class BuilderComputer : IBuilder
    {
        private Computer computer;

        public BuilderComputer(IComputerRequest request, Importance importance, IStrategyOrderBy orderBy, IFactoryCompatibility factoryCompatibility, IFactoryEnough factoryEnough, IComponentReadOnlyRepository repository)
        {
            Components = orderBy.GetOrderedComponents(repository.All, importance);
            Request = request;
            SetComputer();
            FactoryCompatibilty = factoryCompatibility;
            FactoryEnough = factoryEnough;
        }

        public void AddCpu(Component root)
        {
            if (root.IsEnough(FactoryEnough[Enough.Level], Request.Specification.Cpu))
            {
                Add(root);
            }
            else
            {
                ThrowInvalidAdd();
            }
        }

        public void AddFan()
        {
            if (computer[TypePart.cpu].IsEnough(FactoryEnough[Enough.Fan], Request.Specification.Fan))
            {
                Add(Components.Where(c => c.IsType(TypePart.fan))
                                           .Where(c => c.IsCompatibleWith(FactoryCompatibilty[Compatibility.Fan], computer[TypePart.cpu]))
                                           .FirstOrDefault(c => c.IsEnough(FactoryEnough[Enough.Level], Request.Specification.Fan)));
            }
        }

        public void AddGpu()
        {
            if (computer[TypePart.cpu].IsEnough(FactoryEnough[Enough.Gpu], Request.Specification.Gpu))
            {
                Add(Components.Where(c => c.IsType(TypePart.gpu))
                                           .FirstOrDefault(c => c.IsEnough(FactoryEnough[Enough.Level], Request.Specification.Gpu)));
            }
            else if (!computer[TypePart.cpu].IsCompatibleWith(FactoryCompatibilty[Compatibility.VideoCpu], computer[TypePart.mother]))
            {
                ThrowInvalidAdd();
            }
        }

        public void AddHardDiskHDD()
        {
            Add(Components.Where(c => c.IsType(TypePart.hdd))
                                       .FirstOrDefault(c => c.IsEnough(FactoryEnough[Enough.Capacity], Request.Specification.Hdd)));
        }

        public void AddHardDiskSSD()
        {
            Add(Components.Where(c => c.IsType(TypePart.ssd))
                                       .FirstOrDefault(c => c.IsEnough(FactoryEnough[Enough.Capacity], Request.Specification.Ssd)));
        }

        public void AddMother()
        {
            Add(Components.Where(c => c.IsType(TypePart.mother))
                                       .Where(c => c.IsCompatibleWith(FactoryCompatibilty[Compatibility.Mother], computer[TypePart.cpu]))
                                       .Where(c => c.IsEnough(FactoryEnough[Enough.Channels], computer[TypePart.cpu].Channels))
                                       .FirstOrDefault(c => c.IsEnough(FactoryEnough[Enough.Level], Request.Specification.Mother)));
        }

        public void AddRam()
        {

            if (computer[TypePart.cpu].IsEnough(FactoryEnough[Enough.OneRam], Request.Specification.Ram))
            {
                Add(Components.Where(c => c.IsType(TypePart.ram))
                                           .Where(c => c.IsCompatibleWith(FactoryCompatibilty[Compatibility.Ram], computer[TypePart.cpu]))
                                           .FirstOrDefault(c => c.IsEnough(FactoryEnough[Enough.Capacity],
                                                                Request.Specification.Ram / computer[TypePart.cpu].Channels))
                    , computer[TypePart.cpu].Channels);

            }
            else
            {
                Add(Components.FirstOrDefault(c => c.IsEnough(FactoryEnough[Enough.Capacity], Request.Specification.Ram)));
            }
        }

        public void AddTower()
        {
            Add(Components.Where(c => c.IsType(TypePart.tower))
                                       .Where(c => c.IsCompatibleWith(FactoryCompatibilty[Compatibility.CaseFan], computer[TypePart.fan]))
                                       .FirstOrDefault(c => c.IsCompatibleWith(FactoryCompatibilty[Compatibility.CaseMother], computer[TypePart.mother])));
        }

        public void AddPsu()
        {
            Add(Components.Where(c => c.IsType(TypePart.psu))
                                       .FirstOrDefault(c => c.IsEnough(FactoryEnough[Enough.Capacity], computer.TotalConsumption)));
        }

        private void Add(Component component, int quantity = 1)
        {
            if (ValidComponent(component, quantity) && ValidBudget(component))
            {
                computer.Add(component, quantity);
            }
            else
            {
                ThrowInvalidAdd();
            }
        }

        private bool ValidBudget(Component component)
        {
            return computer.Price + component.Price <= Request.Budget;
        }

        private bool ValidComponent(Component component, int quantity)
        {
            return component != null && component.IsEnough(FactoryEnough[Enough.Stock], quantity);
        }

        private void ThrowInvalidAdd()
        {
            SetComputer();
            InvalidAddException.Throw();
        }

        private void SetComputer()
        {
            computer = new Computer
            {
                TypeUse = Request.Specification.Use.ToString()
            };
        }

        public Computer Computer
        {
            get
            {
                var computer = this.computer;
                SetComputer();
                return computer;
            }
        }

        public IComputerRequest Request { get; }
        public IFactoryCompatibility FactoryCompatibilty { get; }
        public IFactoryEnough FactoryEnough { get; }
        public IEnumerable<Component> Components { get; }
    }
}
