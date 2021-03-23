using Application.Repositories.Interfaces.Orders;
using Domain.Orders;
using Infra.Interfaces.Connections;
using System.Data.SqlClient;

namespace Infra.Repositories.Implementations.Orders
{
    public class BuildOrderRepository : IBuildOrderRepository
    {
        private readonly IConnection connection;

        public BuildOrderRepository(IConnection connection)
        {
            this.connection = connection;
        }

        public void Build(Order orderToBuild)
        {
            connection.Execute(new SqlCommand[] { CommandBuild(orderToBuild) });
        }

        private SqlCommand CommandBuild(Order orderToBuild)
        {
            var commandBuild = new SqlCommand("UPDATE [Order] SET  OrderState = @State WHERE ID = @Id");
            commandBuild.Parameters.AddWithValue("State", (int)orderToBuild.State);
            commandBuild.Parameters.AddWithValue("Id", orderToBuild.Id);
            return commandBuild;
        }
    }
}
