using Domain.Compatibilities.Interfaces;
using Domain.Components;

namespace Domain.Compatibilities.Implementations
{
    public class CompatibleRam : ICompatible
    {
        private const int HIGH_FRECUENCY = 2933;

        public bool IsCompatibleWith(Component component, Component componentToCompare)
        {
            bool compatible = component.TypeMemory == componentToCompare.TypeMemory && component.MaxFrecuency <= componentToCompare.MaxFrecuency;
            bool highFrecuency = componentToCompare.MaxFrecuency >= HIGH_FRECUENCY;
            return componentToCompare.NeedHighFrecuency ? highFrecuency && compatible : compatible;
        }
    }
}
