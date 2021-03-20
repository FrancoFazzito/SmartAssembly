using Application.Commands.Build.Importances;
using Domain.Components;
using System.Collections.Generic;
using System.Linq;

namespace Application.Strategies.OrderBy
{
    public class StrategyOrderBy : IStrategyOrderBy
    {
        public IEnumerable<Component> GetOrderedComponents(IEnumerable<Component> components, Importance order)
        {
            switch (order)
            {
                case Importance.Price:
                    return components.OrderBy(c => c.Price);
                case Importance.Perfomance:
                    return components.OrderByDescending(c => c.PerfomanceLevel);
                default:
                    return null;
            }
        }
    }

}
