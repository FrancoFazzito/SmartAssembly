using Domain.Compatibilities.Interfaces;
using Domain.Components;

namespace Domain.Compatibilities.Implementations
{
    public class CompatibleType : ICompatible
    {
        public bool IsCompatibleWith(Component component, Component componentToCompare)
        {
            return component.TypePart == componentToCompare.TypePart;
        }
    }
}