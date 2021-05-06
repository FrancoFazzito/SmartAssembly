using Domain.Clients;
using System.Collections.Generic;

namespace Application.Repositories.Interfaces
{
    public interface IClientReadOnlyRepository
    {
        IEnumerable<Client> All { get; }

        Client GetByEmail(string email);
    }
}