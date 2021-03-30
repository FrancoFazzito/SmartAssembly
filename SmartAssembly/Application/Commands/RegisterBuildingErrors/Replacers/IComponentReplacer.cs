using Domain.Components;

namespace Application.Commands.RegisterBuildingError
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