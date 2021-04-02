using Application.Repositories.Interfaces;
using Domain.Computers;
using Domain.Orders.States;
using Infra.Connections;
using System.Data.SqlClient;

namespace Infra.Repositories.Implementations.Errors
{
    public class ErrorOrderWriteOnlyRepository : IErrorOrderWriteOnlyRepository
    {
        private const string PARAM_COMPUTER = "id";
        private const string PARAM_COMMENTARY = "commentary";
        private const string PARAM_STATE_ORDER = "state";
        private readonly IConnection connection;

        public ErrorOrderWriteOnlyRepository(IConnection connection)
        {
            this.connection = connection;
        }

        public void Insert(Computer computer, string commentary, OrderState newState)
        {
            connection.Execute(new SqlCommand[] { CommandError(computer, commentary), CommandUpdateError(computer, commentary, newState), CommandUncompleted(computer) });
        }

        private SqlCommand CommandUpdateError(Computer computer, string commentary, OrderState newState)
        {
            var commandUpdateError = new SqlCommand($"update [Order] set Commentary += @{PARAM_COMMENTARY}, OrderState = @{PARAM_STATE_ORDER} where ID = (select o.ID from [Order] o inner join Computer c on c.ID_Order = o.ID where c.ID = @{PARAM_COMPUTER})");
            commandUpdateError.Parameters.AddWithValue(PARAM_COMMENTARY, commentary);
            commandUpdateError.Parameters.AddWithValue(PARAM_COMPUTER, computer.Id);
            commandUpdateError.Parameters.AddWithValue(PARAM_STATE_ORDER, newState);
            return commandUpdateError;
        }

        private SqlCommand CommandError(Computer computer, string commentary)
        {
            var command = new SqlCommand($"INSERT INTO Computer_Error(ID_Computer,Commentary,DateError) VALUES (@{PARAM_COMPUTER},@{PARAM_COMMENTARY},GETDATE())");
            command.Parameters.AddWithValue(PARAM_COMPUTER, computer.Id);
            command.Parameters.AddWithValue(PARAM_COMMENTARY, commentary);
            return command;
        }

        private SqlCommand CommandUncompleted(Computer computer)
        {
            var commandBuild = new SqlCommand("UPDATE Computer SET Completed = 0 WHERE Computer.ID = @id");
            commandBuild.Parameters.AddWithValue("id", computer.Id);
            return commandBuild;
        }
    }
}