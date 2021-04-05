using Domain.Components;
using Domain.Importance;
using System.Collections.Generic;
using System.Linq;

namespace Application.Common.Strategies.OrderBy
{
    public class StrategyOrderBy : IStrategyOrderBy
    {
        public IEnumerable<Component> GetOrderedComponents(IEnumerable<Component> components, Importance order)
        {
            if (order == Importance.price)
            {
                return components.OrderBy(c => c.Price);
            }
            return components.OrderByDescending(c => c.PerfomanceLevel);
        }
    }
}