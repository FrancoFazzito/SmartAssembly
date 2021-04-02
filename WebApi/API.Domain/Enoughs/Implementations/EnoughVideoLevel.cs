using Domain.Components;
using Domain.Enoughs.Interfaces;

namespace Domain.Enoughs.Implementations
{
    public class EnoughVideoLevel : IEnough
    {
        public bool IsEnough(Component component, int quantity)
        {
            return component.VideoLevel < quantity;
        }
    }
}