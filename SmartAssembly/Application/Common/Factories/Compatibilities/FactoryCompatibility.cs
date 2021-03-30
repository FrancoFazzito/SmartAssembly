using Domain.Compatibilities.Implementations;
using Domain.Compatibilities.Interfaces;
using Domain.Compatibility.Enums;
using System.Collections.Generic;

namespace Application.Common.Factories.Compatibilities
{
    public class FactoryCompatibility : IFactoryCompatibility
    {
        private readonly Dictionary<Compatibility, ICompatible> compatibilities;

        public FactoryCompatibility()
        {
            compatibilities = new Dictionary<Compatibility, ICompatible>
            {
                { Compatibility.Cpu, new CompatibleCpu() },
                { Compatibility.CaseFan, new CompatibleTowerFan() },
                { Compatibility.CaseMother, new CompatibleTowerMother() },
                { Compatibility.Fan, new CompatibleFan() },
                { Compatibility.Mother, new CompatibleMother() },
                { Compatibility.Ram, new CompatibleRam() },
                { Compatibility.Type, new CompatibleType() },
                { Compatibility.IntegratedVideo, new CompatibleIntegratedVideo() }
            };
        }

        public ICompatible this[Compatibility compatibility] => compatibilities[compatibility];
    }
}
