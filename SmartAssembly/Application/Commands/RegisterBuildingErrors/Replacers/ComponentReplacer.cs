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

namespace Application.Commands.RegisterBuildingError
{
    internal class ComponentReplacer : IComponentReplacer
    {
        private readonly Dictionary<TypePart, Func<Component>> replaces;
        private readonly IFactoryCompatibility compatibilities;
        private readonly IFactoryEnough enoughs;
        private readonly IEnumerable<Component> components;
        private readonly Computer computer;
        private readonly Component component;

        public ComponentReplacer(Computer computer, Component component, IComponentReadOnlyRepository componentRepository, IFactoryCompatibility compatibilities, IFactoryEnough enoughs)
        {
            this.compatibilities = compatibilities;
            this.enoughs = enoughs;
            this.computer = computer;
            this.component = component;
            components = componentRepository.All.Where(c => c.TypePart == component.TypePart)
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
            return replaces[component.TypePart]();
        }

        public Component ReplaceCpu()
        {
            return components.FirstOrDefault(c => c.IsCompatibleWith(compatibilities[Compatibility.Cpu], component));
        }

        public Component ReplaceMother()
        {
            return components.Where(c => c.IsCompatibleWith(compatibilities[Compatibility.CaseMother], computer[TypePart.tower]))
                             .Where(c => computer[TypePart.ram].IsCompatibleWith(compatibilities[Compatibility.Ram], c))
                             .FirstOrDefault(c => c.IsCompatibleWith(compatibilities[Compatibility.Mother], component));
        }

        public Component ReplaceFan()
        {
            return components.Where(c => c.IsCompatibleWith(compatibilities[Compatibility.CaseFan], computer[TypePart.tower]))
                             .FirstOrDefault(c => c.IsCompatibleWith(compatibilities[Compatibility.Fan], component));
        }

        public Component ReplaceRam()
        {
            return components.Where(c => c.IsEnough(enoughs[Enough.Capacity], component.Capacity))
                             .FirstOrDefault(c => c.IsCompatibleWith(compatibilities[Compatibility.Ram], component));
        }

        public Component ReplaceGpu()
        {
            return components.FirstOrDefault();
        }

        public Component ReplaceCapacity()
        {
            return components.FirstOrDefault(c => c.IsEnough(enoughs[Enough.Capacity], component.Capacity));
        }

        public Component ReplaceTower()
        {
            return components.Where(c => c.IsCompatibleWith(compatibilities[Compatibility.CaseMother], component))
                             .FirstOrDefault(c => c.IsCompatibleWith(compatibilities[Compatibility.CaseFan], component));
        }

        public Component ReplaceAccesory()
        {
            return components.FirstOrDefault(c => c.IsCompatibleWith(compatibilities[Compatibility.Accesory], component));
        }
    }
}
