using Domain.Components;

namespace Domain.Compatibilities.Interfaces
{
    public interface ICompatible
    {
        bool IsCompatibleWith(Component component, Component componentToCompare);
    }
}