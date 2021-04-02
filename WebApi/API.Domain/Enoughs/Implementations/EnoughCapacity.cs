using Domain.Components;
using Domain.Enoughs.Interfaces;

namespace Domain.Enoughs.Implementations
{
    public class EnoughCapacity : IEnough
    {
        public bool IsEnough(Component component, int quantity)
        {
            return component.Capacity >= quantity;
        }
    }
}