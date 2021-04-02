using System.Collections.Generic;

namespace Application.Repositories.Interfaces
{
    public interface IClientReadOnlyRepository
    {
        IEnumerable<Domain.Clients.Client> All { get; }

        Domain.Clients.Client GetByEmail(string email);
    }
}