using Domain.Components;
using Domain.Enoughs.Interfaces;

namespace Domain.Enoughs.Implementations
{
    public class EnoughFan : IEnough
    {
        public bool IsEnough(Component component, int quantity)
        {
            return component.FanLevel <= quantity;
        }
    }
}
