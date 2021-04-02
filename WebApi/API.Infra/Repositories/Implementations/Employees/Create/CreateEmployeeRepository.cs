using Application.Repositories.Interfaces;
using Domain.Employees;
using Infra.Connections;
using System.Data.SqlClient;

namespace Infra.Repositories.Implementations.Employees.Create
{
    public class CreateEmployeeRepository : ICreate<Employee>
    {
        private readonly IConnection connection;

        public CreateEmployeeRepository(IConnection connection)
        {
            this.connection = connection;
        }

        public void Create(Employee value)
        {
            var command = new SqlCommand("INSERT INTO Employee VALUES (@email)");
            command.Parameters.AddWithValue("email", value.Email);
            connection.Execute(command);
        }
    }
}