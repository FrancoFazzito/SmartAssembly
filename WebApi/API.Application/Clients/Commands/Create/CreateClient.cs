using Application.Repositories.Interfaces;
using Domain.Clients;

namespace Application.Clients.Commands.Create
{
    public class CreateClient
    {
        private readonly ICreate<Client> create;

        public CreateClient(ICreate<Client> create)
        {
            this.create = create;
        }

        public void Create(Client value)
        {
            create.Create(value);
        }
    }
}
