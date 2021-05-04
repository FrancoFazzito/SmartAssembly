using System.Collections.Generic;

namespace Application.Repositories.Interfaces
{
    public interface IClientReadOnlyRepository
    {
        IEnumerable<Domain.Clients.Client> GetAll();
        Domain.Clients.Client GetByEmail(string email);
    }
}