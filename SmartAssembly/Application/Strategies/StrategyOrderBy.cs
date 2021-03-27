using Application.Commands.BuildComputers.Importances;
using Domain.Components;
using System.Collections.Generic;
using System.Linq;

namespace Application.Strategies.OrderBy
{
    public class StrategyOrderBy : IStrategyOrderBy
    {

        public IEnumerable<Component> GetOrderedComponents(IEnumerable<Component> components, Importance order)
        {
            return order == Importance.Price ? components.OrderBy(c => c.Price) : components.OrderByDescending(c => c.PerfomanceLevel);
        }
    }

}
