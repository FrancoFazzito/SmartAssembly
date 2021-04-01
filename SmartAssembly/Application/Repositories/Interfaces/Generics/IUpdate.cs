namespace Application.Repositories.Interfaces
{
    public interface IUpdate<in T>
    {
        void Update(T value);
    }
}