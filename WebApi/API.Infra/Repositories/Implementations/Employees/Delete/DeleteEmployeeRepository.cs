using Application.Repositories.Interfaces;
using Infra.Connections;
using System.Data.SqlClient;

namespace Infra.Repositories.Implementations.Employees.Delete
{
    public class DeleteEmployeeRepository : IDeleteByEmail
    {
        private readonly IConnection connection;

        public DeleteEmployeeRepository(IConnection connection)
        {
            this.connection = connection;
        }

        public void Delete(string email)
        {
            var command = new SqlCommand("DELETE FROM Employee WHERE Email = @email");
            command.Parameters.AddWithValue("email", email);
            connection.Execute(command);
        }
    }
}