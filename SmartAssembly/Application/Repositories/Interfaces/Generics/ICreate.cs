namespace Application.Repositories.Interfaces
{
    public interface ICreate<in T>
    {
        void Create(T value);
    }
}