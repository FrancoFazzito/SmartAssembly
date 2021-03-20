using Application.Factories.Compatibilities;
using Application.Factories.Enoughs;
using Domain.Components;

namespace Application.Commands.RegisterComputerError.Replacers
{
    internal interface IComponentReplacer
    {
        IFactoryCompatibility Compatibilities { get; }
        IFactoryEnough Enoughs { get; }

        Component Replace();
        Component ReplaceAccesory();
        Component ReplaceCapacity();
        Component ReplaceCpu();
        Component ReplaceFan();
        Component ReplaceGpu();
        Component ReplaceMother();
        Component ReplaceRam();
        Component ReplaceTower();
    }
}