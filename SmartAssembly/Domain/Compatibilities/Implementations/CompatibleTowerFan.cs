using Domain.Compatibilities.Interfaces;
using Domain.Components;

namespace Domain.Compatibilities.Implementations
{
    public class CompatibleTowerFan : ICompatible
    {
        public bool IsCompatibleWith(Component component, Component componentToCompare)
        {
            return componentToCompare == null || component.FanSize >= componentToCompare.FanSize;
        }
    }
}
