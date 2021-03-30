using Application.Repositories.Interfaces.Error;
using Domain.Components;
using Domain.Computers;
using Domain.Orders.States;
using Infra.Connections;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Infra.Repositories.Implementations.Errors
{
    public class ErrorBuildingWriteOnlyRepository : IErrorBuildingWriteOnlyRepository //separate repository with replace and withouth replace
    {
        private const string PARAM_COMPUTER = "ID_Computer";
        private const string PARAM_COMPONENT_REPLACE = "ID_Component_Replace";
        private const string PARAM_COMMENTARY = "Commentary";
        private const string PARAM_COMPONENT_ERROR = "ID_Component_Error";
        private const string PARAM_STATE_ORDER = "State";
        private const string PARAM_ID = "id";
        private const string PARAM_QUANTITY = "Quantity";
        private readonly IConnection connection;

        public ErrorBuildingWriteOnlyRepository(IConnection connection)
        {
            this.connection = connection;
        }

        public void Insert(Component componentWithError, Computer computer, string commentary, OrderState newStateOrder, bool deleteComponentError)
        {
            var commands = new List<SqlCommand>
            {
                CommandErrorWithouthReplace(componentWithError, computer.Id, commentary),
                CommandUpdateOrder(computer.Id, commentary, newStateOrder)
            };

            if (!deleteComponentError)
            {
                commands.Add(CommandUpdateComponentWithErrorStock(componentWithError, computer.QuantityOf(componentWithError)));
            }

            connection.Execute(commands);
        }

        private SqlCommand CommandUpdateComponentWithErrorStock(Component componentToReplace, int quantity)
        {
            var command = new SqlCommand($"UPDATE Component SET Stock += @{PARAM_QUANTITY} WHERE Component.ID = @{PARAM_ID}");
            command.Parameters.AddWithValue(PARAM_ID, componentToReplace.Id);
            command.Parameters.AddWithValue(PARAM_QUANTITY, quantity);
            return command;
        }

        private SqlCommand CommandUpdateOrder(int idComputer, string commentary, OrderState newStateOrder)
        {
            var commandUpdateError = new SqlCommand($"update [Order] set Commentary += @{PARAM_COMMENTARY}, OrderState = @{PARAM_STATE_ORDER} where ID = (select o.ID from [Order] o inner join Computer c on c.ID_Order = o.ID where c.ID = @{PARAM_COMPUTER})");
            commandUpdateError.Parameters.AddWithValue(PARAM_COMMENTARY, commentary);
            commandUpdateError.Parameters.AddWithValue(PARAM_COMPUTER, idComputer);
            commandUpdateError.Parameters.AddWithValue(PARAM_STATE_ORDER, newStateOrder);
            return commandUpdateError;
        }

        private SqlCommand CommandErrorWithouthReplace(Component componentWithError, int idComputer, string commentary)
        {
            var commandError = new SqlCommand($"INSERT INTO Computer_Error VALUES (@{PARAM_COMPUTER},@{PARAM_COMPONENT_ERROR},@{PARAM_COMPONENT_REPLACE},@{PARAM_COMMENTARY},GETDATE())");
            commandError.Parameters.AddWithValue(PARAM_COMPUTER, idComputer);
            commandError.Parameters.AddWithValue(PARAM_COMPONENT_ERROR, componentWithError.Id);
            commandError.Parameters.AddWithValue(PARAM_COMPONENT_REPLACE, DBNull.Value);
            commandError.Parameters.AddWithValue(PARAM_COMMENTARY, commentary);
            return commandError;
        }
    }
}
