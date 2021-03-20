using Domain.Components;
using Domain.Enoughs.Interfaces;

namespace Domain.Enoughs.Implementations
{
    public class EnoughOneRam : IEnough
    {
        public bool IsEnough(Component component, int capacity)
        {
            return component.PerfomanceLevel >= 30 && capacity >= 4;
        }
    }
}
