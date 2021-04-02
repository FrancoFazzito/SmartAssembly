using Domain.Components;

namespace Application.Orders.Commands.RegisterError
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