using Application.Repositories.Interfaces;
using Domain.Orders;
using Infra.Connections;
using System.Data.SqlClient;

namespace Infra.Repositories.Implementations.Orders
{
    public class DeliverOrderRepository : IDeliverOrderRepository
    {
        private const string PARAMETER_STATE = "State";
        private const string PARAMETER_ID = "Id";
        private const string PARAMETER_DATE_DELIVERED = "date";
        private readonly IConnection connection;

        public DeliverOrderRepository(IConnection connection)
        {
            this.connection = connection;
        }

        public void Deliver(Order orderToDeliver)
        {
            connection.Execute(new SqlCommand[] { CommandBuild(orderToDeliver) });
        }

        private SqlCommand CommandBuild(Order orderToDeliver)
        {
            var commandBuild = new SqlCommand($"UPDATE [Order] SET OrderState = @{PARAMETER_STATE}, DateDelivered = @{PARAMETER_DATE_DELIVERED} WHERE ID = @{PARAMETER_ID}");
            commandBuild.Parameters.AddWithValue(PARAMETER_STATE, (int)orderToDeliver.State);
            commandBuild.Parameters.AddWithValue(PARAMETER_ID, orderToDeliver.Id);
            commandBuild.Parameters.AddWithValue(PARAMETER_DATE_DELIVERED, orderToDeliver.DateDelivered);
            return commandBuild;
        }
    }
}