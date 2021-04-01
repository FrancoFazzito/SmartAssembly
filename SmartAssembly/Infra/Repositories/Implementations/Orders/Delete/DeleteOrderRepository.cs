using Application.Repositories.Interfaces;
using Domain.Orders;
using Infra.Connections;
using System.Data.SqlClient;

namespace Infra.Repositories.Implementations.Orders.Delete
{
    public class DeleteOrderRepository : IDelete<Order>
    {
        private readonly IConnection connection;

        public DeleteOrderRepository(IConnection connection)
        {
            this.connection = connection;
        }

        public void Delete(int id)
        {
            var command = new SqlCommand("DELETE FROM [Order] WHERE ID = @id");
            command.Parameters.AddWithValue("id", id);
            connection.Execute(command);
        }
    }
}