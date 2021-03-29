using Application.Factories.Compatibilities;
using Application.Factories.Enoughs;
using Application.Repositories.Components.Interfaces;
using Domain.Compatibility.Enums;
using Domain.Components;
using Domain.Components.Types;
using Domain.Computers;
using Domain.Enoughs.Enums;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Application.Commands.RegisterBuildError.Replacers
{
    internal class ComponentReplacer : IComponentReplacer
    {
        private readonly Dictionary<TypePart, Func<Component>> replaces;

        public ComponentReplacer(Computer computer, Component component, IComponentReadOnlyRepository componentRepository, IFactoryCompatibility compatibilities, IFactoryEnough enoughs)
        {
            Compatibilities = compatibilities;
            Enoughs = enoughs;
            Computer = computer;
            Component = component;
            Components = componentRepository.All.Where(c => c.TypePart == component.TypePart)
                                                .Where(c => c.IsEnough(enoughs[Enough.Level], GetLevelToReplace(component)))
                                                .Where(c => c.Id != component.Id)
                                                .OrderBy(c => c.Price);

            replaces = new Dictionary<TypePart, Func<Component>>
            {
                { TypePart.cpu, ReplaceCpu },
                { TypePart.mother, ReplaceMother },
                { TypePart.fan, ReplaceFan },
                { TypePart.ram, ReplaceRam },
                { TypePart.gpu, ReplaceGpu },
                { TypePart.hdd, ReplaceCapacity },
                { TypePart.ssd, ReplaceCapacity },
                { TypePart.tower, ReplaceTower },
                { TypePart.psu, ReplaceCapacity },
                { TypePart.accesory, ReplaceAccesory }
            };
        }

        private int GetLevelToReplace(Component component)
        {
            return (int)(0.70 * component.PerfomanceLevel);
        }

        public Component Replace()
        {
            return replaces[Component.TypePart]();
        }

        public Component ReplaceCpu()
        {
            return Components.FirstOrDefault(c => c.IsCompatibleWith(Compatibilities[Compatibility.Cpu], Component));
        }

        public Component ReplaceMother()
        {
            return Components.Where(c => c.IsCompatibleWith(Compatibilities[Compatibility.CaseMother], Computer[TypePart.tower]))
                             .Where(c => Computer[TypePart.ram].IsCompatibleWith(Compatibilities[Compatibility.Ram], c))
                             .FirstOrDefault(c => c.IsCompatibleWith(Compatibilities[Compatibility.Mother], Component));
        }

        public Component ReplaceFan()
        {
            return Components.Where(c => c.IsCompatibleWith(Compatibilities[Compatibility.CaseFan], Computer[TypePart.tower]))
                             .FirstOrDefault(c => c.IsCompatibleWith(Compatibilities[Compatibility.Fan], Component));
        }

        public Component ReplaceRam()
        {
            return Components.Where(c => c.IsEnough(Enoughs[Enough.Capacity], Component.Capacity))
                             .FirstOrDefault(c => c.IsCompatibleWith(Compatibilities[Compatibility.Ram], Component));
        }

        public Component ReplaceGpu()
        {
            return Components.FirstOrDefault();
        }

        public Component ReplaceCapacity()
        {
            return Components.FirstOrDefault(c => c.IsEnough(Enoughs[Enough.Capacity], Component.Capacity));
        }

        public Component ReplaceTower()
        {
            return Components.Where(c => c.IsCompatibleWith(Compatibilities[Compatibility.CaseMother], Component))
                             .FirstOrDefault(c => c.IsCompatibleWith(Compatibilities[Compatibility.CaseFan], Component));
        }

        public Component ReplaceAccesory()
        {
            return Components.FirstOrDefault(c => c.IsCompatibleWith(Compatibilities[Compatibility.Accesory], Component));
        }

        public IFactoryCompatibility Compatibilities { get; }
        public IFactoryEnough Enoughs { get; }
        public IEnumerable<Component> Components { get; }
        public Computer Computer { get; }
        public Component Component { get; }
    }
}
