using Domain.Components;
using Domain.Importance;
using System.Collections.Generic;

namespace Application.Common.Strategies.OrderBy
{
    public interface IStrategyOrderBy
    {
        IEnumerable<Component> GetOrderedComponents(IEnumerable<Component> components, Importance order);
    }
}