using Domain.Components;

namespace Application.Commands.RegisterBuildError.Replacers
{
    internal interface IComponentReplacer
    {
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