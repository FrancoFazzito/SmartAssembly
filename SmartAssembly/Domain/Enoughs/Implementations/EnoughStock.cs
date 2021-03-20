using Domain.Components;
using Domain.Enoughs.Interfaces;

namespace Domain.Enoughs.Implementations
{
    public class EnoughStock : IEnough
    {
        public bool IsEnough(Component component, int quantity)
        {
            return component.Stock >= quantity;
        }
    }
}
