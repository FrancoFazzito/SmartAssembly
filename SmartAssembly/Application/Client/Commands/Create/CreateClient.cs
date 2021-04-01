using Application.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Client.Commands.Create
{
    public class CreateClient
    {
        private readonly ICreate<Domain.Clients.Client> create;

        public CreateClient(ICreate<Domain.Clients.Client> create)
        {
            this.create = create;
        }

        public void Create(Domain.Clients.Client value)
        {
            create.Create(value);
        }
    }
}
