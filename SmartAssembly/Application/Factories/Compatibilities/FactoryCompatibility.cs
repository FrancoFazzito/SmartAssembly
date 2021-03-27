using Domain.Compatibilities.Implementations;
using Domain.Compatibilities.Interfaces;
using Domain.Compatibility.Enums;
using System.Collections.Generic;

namespace Application.Factories.Compatibilities
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
                { Compatibility.IntegratedVideo, new CompatibleVideoCpu() },
                { Compatibility.Accesory, new CompatibleVideoCpu() }
            };
        }

        public ICompatible this[Compatibility compatibility] => compatibilities[compatibility];
    }
}
