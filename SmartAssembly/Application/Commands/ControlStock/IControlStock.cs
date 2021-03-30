using Domain.Components;
using System.Collections.Generic;

namespace Application.Commands.ControlStock
{
    public interface IControlStock
    {
        IEnumerable<Component> ComponentsLowStock { get; }
    }
}