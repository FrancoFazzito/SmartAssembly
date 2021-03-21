using Domain.Clients;
using System.Collections.Generic;

namespace Application.Repositories.Interfaces.Clients
{
    public interface IClientReadOnlyRepository
    {
        IEnumerable<Client> All { get; }
        Client GetByName(string email);
    }
}
