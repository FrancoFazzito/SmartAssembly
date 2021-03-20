using Domain.Components;
using Domain.Enoughs.Interfaces;

namespace Domain.Enoughs.Implementations
{
    public class EnoughChannels : IEnough
    {
        public bool IsEnough(Component component, int quantity)
        {
            return component.Channels >= quantity;
        }
    }
}
