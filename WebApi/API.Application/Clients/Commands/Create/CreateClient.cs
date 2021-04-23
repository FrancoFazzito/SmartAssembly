using Application.Common.Exceptions;
using Application.Repositories.Interfaces;
using Domain.Clients;

namespace Application.Clients.Commands.Create
{
    public class CreateClient
    {
        private readonly ICreate<Client> create;
        private readonly IClientReadOnlyRepository read;

        public CreateClient(ICreate<Client> create, IClientReadOnlyRepository read)
        {
            this.create = create;
            this.read = read;
        }

        public void Create(Client value)
        {
            if (read.GetByEmail(value.Email) != null)
            {
                throw new ClientAlreadyExistsException();
            }
            create.Create(value);
        }
    }
}