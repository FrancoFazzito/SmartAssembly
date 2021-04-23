using Application.Repositories.Interfaces;
using Domain.Clients;
using System.Collections.Generic;

namespace Application.Clients.Commands.Create
{
    public class ReadClient
    {
        private readonly IClientReadOnlyRepository read;

        public ReadClient(IClientReadOnlyRepository read)
        {
            this.read = read;
        }

        public IEnumerable<Client> All => read.All;
    }
}