using Application.Repositories.Interfaces;
using Infra.Connections;
using System.Data.SqlClient;

namespace Infra.Repositories.Implementations.Computers
{
    public class DeleteComputerRepository : IDeleteById
    {
        private readonly IConnection connection;

        public DeleteComputerRepository(IConnection connection)
        {
            this.connection = connection;
        }

        public void Delete(int id)
        {
            var command = new SqlCommand("DELETE FROM Computer WHERE ID = @id");
            command.Parameters.AddWithValue("id", id);
            connection.Execute(command);
        }
    }
}