using Domain.Compatibilities.Interfaces;
using Domain.Components;

namespace Domain.Compatibilities.Implementations
{
    public class CompatibleCpu : ICompatible
    {
        public bool IsCompatibleWith(Component component, Component componentToCompare)
        {
            return component.Socket == componentToCompare.Socket && component.MaxFrecuency <= componentToCompare.MaxFrecuency;
        }
    }
}