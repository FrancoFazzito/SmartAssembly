using Domain.Components;

namespace Domain.Enoughs.Interfaces
{
    public interface IEnough
    {
        bool IsEnough(Component Component, int quantity);
    }
}
