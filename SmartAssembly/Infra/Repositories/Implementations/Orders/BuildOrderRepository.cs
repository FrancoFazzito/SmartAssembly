using Application.Repositories.Interfaces.Orders;
using Domain.Orders;
using Infra.Interfaces.Connections;
using System.Data.SqlClient;

namespace Infra.Repositories.Implementations.Orders
{
    public class BuildOrderRepository : IBuildOrderRepository
    {
        private const string PARAMETER_STATE = "State";
        private const string PARAMETER_ID = "Id";
        private readonly IConnection connection;

        public BuildOrderRepository(IConnection connection)
        {
            this.connection = connection;
        }

        public void Build(Order orderToBuild)
        {
            connection.Execute(new SqlCommand[] { CommandBuild(orderToBuild), CommandCompleted(orderToBuild) });
        }

        private SqlCommand CommandBuild(Order orderToBuild)
        {
            var commandBuild = new SqlCommand($"UPDATE [Order] SET  OrderState = @{PARAMETER_STATE} WHERE ID = @{PARAMETER_ID}");
            commandBuild.Parameters.AddWithValue(PARAMETER_STATE, (int)orderToBuild.State);
            commandBuild.Parameters.AddWithValue(PARAMETER_ID, orderToBuild.Id);
            return commandBuild;
        }

        private SqlCommand CommandCompleted(Order orderToBuild)
        {
            var commandBuild = new SqlCommand($"UPDATE Computer SET Completed = 1 WHERE Computer.ID_Order = @{PARAMETER_ID}");
            commandBuild.Parameters.AddWithValue(PARAMETER_ID, orderToBuild.Id);
            return commandBuild;
        }
    }
}
