using Application.Repositories.Interfaces;
using Infra.Connections;
using System.Data.SqlClient;

namespace Infra.Repositories.Implementations.TypeUses.Delete
{
    public class DeleteTypeUseRepository : IDeleteByName
    {
        private readonly IConnection connection;

        public DeleteTypeUseRepository(IConnection connection)
        {
            this.connection = connection;
        }

        public void Delete(string name)
        {
            SqlCommand command = new SqlCommand("DELETE FROM TypeUse WHERE Name = @name");
            command.Parameters.AddWithValue("@name", name);
            connection.Execute(command);
        }
    }
}