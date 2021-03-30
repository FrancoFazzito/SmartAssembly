using Domain.Components;
using System.Collections.Generic;

namespace Application.Components.Commands.ControlStock
{
    public interface IControlStock
    {
        IEnumerable<Component> ComponentsLowStock { get; }
    }
}