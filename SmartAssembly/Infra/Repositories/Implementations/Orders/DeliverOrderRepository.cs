using Application.Repositories.Interfaces.Orders;
using Domain.Orders;
using Infra.Interfaces.Connections;
using System.Data.SqlClient;

namespace Infra.Repositories.Implementations.Orders
{
    public class DeliverOrderRepository : IDeliverOrderRepository
    {
        private readonly IConnection connection;

        public DeliverOrderRepository(IConnection connection)
        {
            this.connection = connection;
        }

        public void Deliver(Order orderToBuild)
        {
            connection.Execute(new SqlCommand[] { CommandBuild(orderToBuild) });
        }

        private SqlCommand CommandBuild(Order orderToDeliver)
        {
            var commandBuild = new SqlCommand("UPDATE [Order] SET OrderState = @State, DateDelivered = @date WHERE ID = @Id");
            commandBuild.Parameters.AddWithValue("State", (int)orderToDeliver.State);
            commandBuild.Parameters.AddWithValue("Id", orderToDeliver.Id);
            commandBuild.Parameters.AddWithValue("date",orderToDeliver.DateDelivered);
            return commandBuild;
        }
    }
}
