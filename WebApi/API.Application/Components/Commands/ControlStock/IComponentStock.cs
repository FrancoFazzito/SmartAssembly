using Domain.Components;
using System.Collections.Generic;

namespace Application.Components.Commands.ControlStock
{
    public interface IComponentStock
    {
        IEnumerable<Component> ComponentsLowStock { get; }
    }
}