using Domain.Compatibilities.Interfaces;
using Domain.Components;

namespace Domain.Compatibilities.Implementations
{
    public class CompatibleMother : ICompatible
    {
        public bool IsCompatibleWith(Component component, Component componentToCompare)
        {
            return component.Socket == componentToCompare.Socket && component.TypeMemory == componentToCompare.TypeMemory;
        }
    }
}
