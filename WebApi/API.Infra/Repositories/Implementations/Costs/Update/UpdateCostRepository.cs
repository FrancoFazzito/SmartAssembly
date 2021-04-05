using Application.Repositories.Interfaces.Confuguration.Update;
using Infra.Connections;
using System.Data.SqlClient;

namespace Infra.Repositories.Implementations.Costs.Update
{
    public class UpdateCostRepository : IUpdateCost
    {
        private readonly IConnection connection;

        public UpdateCostRepository(IConnection connection)
        {
            this.connection = connection;
        }

        public void EditValue(string name, int newValue)
        {
            var command = new SqlCommand("UPDATE Costs SET [Value] = @value WHERE [Name] = @name");
            command.Parameters.AddWithValue("value", newValue);
            command.Parameters.AddWithValue("name", name);
            connection.Execute(command);
        }
    }
}
