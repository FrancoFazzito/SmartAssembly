using Domain.Components;

namespace Application.Repositories.Interfaces.Error
{
    public interface IErrorWriteOnlyRepository
    {
        void Insert(Component componentWithError, Component componentToReplace, int idComputer, string commentary);
    }
}
