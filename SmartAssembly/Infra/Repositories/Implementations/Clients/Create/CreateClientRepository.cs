using Application.Repositories.Interfaces;
using Domain.Clients;
using Infra.Connections;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infra.Repositories.Implementations.Clients.Create
{
    class CreateClientRepository : ICreate<Client>
    {
        private readonly IConnection connection;

        public CreateClientRepository(IConnection connection)
        {
            this.connection = connection;
        }

        public void Create(Client value)
        {
            var command = new SqlCommand("INSERT INTO Client VALUES (@email,@name,@number,@adress)");
            command.Parameters.AddWithValue("email",value.Email);
            command.Parameters.AddWithValue("name",value.Name);
            command.Parameters.AddWithValue("number",value.Number);
            command.Parameters.AddWithValue("adress",value.Adress);
            connection.Execute(command);
        }
    }
}
