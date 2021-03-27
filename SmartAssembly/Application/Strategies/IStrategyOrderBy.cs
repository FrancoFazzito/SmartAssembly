using Application.Commands.BuildComputers.Importances;
using Domain.Components;
using System.Collections.Generic;

namespace Application.Strategies.OrderBy
{
    public interface IStrategyOrderBy
    {
        IEnumerable<Component> GetOrderedComponents(IEnumerable<Component> components, Importance order);
    }
}