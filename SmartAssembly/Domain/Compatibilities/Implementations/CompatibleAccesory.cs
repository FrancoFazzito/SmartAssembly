using Domain.Compatibilities.Interfaces;
using Domain.Components;

namespace Domain.Compatibilities.Implementations
{
    public class CompatibleAccesory : ICompatible
    {
        public bool IsCompatibleWith(Component component, Component componentToCompare)
        {
            return component.TypePart == componentToCompare.TypePart;
        }
    }
}
