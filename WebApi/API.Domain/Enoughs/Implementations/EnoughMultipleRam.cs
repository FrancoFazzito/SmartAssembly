using Domain.Components;
using Domain.Enoughs.Interfaces;

namespace Domain.Enoughs.Implementations
{
    public class EnoughMultipleRam : IEnough
    {
        public bool IsEnough(Component component, int? quantity)
        {
            return component.PerfomanceLevel >= 30 && quantity >= 4;
        }
    }
}