using Application.Repositories.Interfaces;
using Infra.Connections;
using System.Data.SqlClient;

namespace Infra.Repositories.Implementations.Clients.Delete
{
    public class DeleteClientRepository : IDeleteByEmail
    {
        private readonly IConnection connection;

        public DeleteClientRepository(IConnection connection)
        {
            this.connection = connection;
        }

        public void Delete(string email)
        {
            var command = new SqlCommand("DELETE FROM Client WHERE Email = @email");
            command.Parameters.AddWithValue("email", email);
            connection.Execute(command);
        }
    }
}