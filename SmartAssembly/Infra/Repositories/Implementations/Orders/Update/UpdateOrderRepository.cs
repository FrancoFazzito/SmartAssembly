using Application.Repositories.Interfaces;
using Domain.Orders;
using Infra.Connections;
using System.Data.SqlClient;

namespace Infra.Repositories.Implementations.Orders.Update
{
    public class UpdateOrderRepository : IUpdate<Order>
    {
        private readonly IConnection connection;

        public UpdateOrderRepository(IConnection connection)
        {
            this.connection = connection;
        }

        public void Update(Order value)
        {
            var command = new SqlCommand("UPDATE [Order] SET [DateRequested] = @dateRequested, [Email_Employee] = @employee_email, [Email_client] = @client_email, [Commentary] = @commentary, [OrderState] = @state, [DateDelivered] = @dateDelivered WHERE ID = @id");
            command.Parameters.AddWithValue("dateRequested", value.DateRequested);
            command.Parameters.AddWithValue("employee_email", value.Employee.Email);
            command.Parameters.AddWithValue("client_email", value.Client.Email);
            command.Parameters.AddWithValue("commentary", value.Commentary);
            command.Parameters.AddWithValue("state", (int)value.State);
            command.Parameters.AddWithValue("dateDelivered", value.DateDelivered);
            command.Parameters.AddWithValue("id", value.Id);
            connection.Execute(command);
        }
    }
}