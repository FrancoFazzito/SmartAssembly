using Domain.Components;

namespace Application.Repositories.Interfaces
{
    public interface IUpdate<T>
    {
        void Update(T value);
    }
}
