using Domain.Components;
using System.Collections.Generic;

namespace Application.Strategies.OrderBy
{
    public interface IStrategyOrderBy
    {
        IEnumerable<Component> GetOrderedComponents(IEnumerable<Component> components, Commands.BuildComputers.Importances.Importance order);
    }
}