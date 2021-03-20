using Domain.Compatibilities.Interfaces;
using Domain.Components;
using System.Linq;

namespace Domain.Compatibilities.Implementations
{
    public class CompatibleFan : ICompatible
    {
        public bool IsCompatibleWith(Component component, Component componentToCompare)
        {
            return component.Socket.Split('-').Contains(componentToCompare.Socket);
        }
    }
}
