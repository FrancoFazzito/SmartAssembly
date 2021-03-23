using Application.Repositories.Interfaces.Error;
using Domain.Components;
using Domain.Orders.States;
using Infra.Interfaces.Connections;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Infra.Repositories.Implementations.Errors
{
    public class ErrorWriteOnlyRepository : IErrorWriteOnlyRepository
    {
        private const string PARAM_COMPUTER = "ID_Computer";
        private const string PARAM_COMPONENT_REPLACE = "ID_Component_Replace";
        private const string PARAM_COMMENTARY = "Commentary";
        private const string PARAM_COMPONENT_ERROR = "ID_Component_Error";
        private const string PARAM_STATE_ORDER = "State";
        private readonly IConnection connection;

        public ErrorWriteOnlyRepository(IConnection connection)
        {
            this.connection = connection;
        }

        //change to computer object y obtener cantidad del component
        public void Insert(Component componentWithError, Component componentToReplace, int idComputer, string commentary, OrderState newStateOrder)
        {
            var commands = new List<SqlCommand>
            {
                CommandError(componentWithError, componentToReplace, idComputer, commentary),
                CommandUpdateOrder(idComputer, commentary, newStateOrder)
            };

            if (ExistsComponent(componentToReplace))
            {
                commands.Add(CommandUpdateComputer(componentToReplace, idComputer));
                //commands.Add(CommandUpdateComponentStock(componentToReplace));
            }
            connection.Execute(commands);
        }

        private SqlCommand CommandUpdateComponentStock(Component componentToReplace, int quantity)
        {
            throw new NotImplementedException();
        }

        private SqlCommand CommandUpdateComputer(Component componentToReplace, int idComputer)
        {
            var commandUpdateComputer = new SqlCommand($"update Component_Computer set ID_Component = @{PARAM_COMPONENT_REPLACE} where ID_Computer = @{PARAM_COMPUTER}");
            commandUpdateComputer.Parameters.AddWithValue(PARAM_COMPONENT_REPLACE, componentToReplace.Id);
            commandUpdateComputer.Parameters.AddWithValue(PARAM_COMPUTER, idComputer);
            return commandUpdateComputer;
        }

        private SqlCommand CommandUpdateOrder(int idComputer, string commentary, OrderState newStateOrder)
        {
            var commandUpdateError = new SqlCommand($"update [Order] set Commentary =+ @{PARAM_COMMENTARY}, OrderState = @{PARAM_STATE_ORDER} where ID = (select o.ID from [Order] o inner join Computer c on c.ID_Order = o.ID where c.ID = @{PARAM_COMPUTER})");
            commandUpdateError.Parameters.AddWithValue(PARAM_COMMENTARY, commentary);
            commandUpdateError.Parameters.AddWithValue(PARAM_COMPUTER, idComputer);
            commandUpdateError.Parameters.AddWithValue(PARAM_STATE_ORDER, newStateOrder);
            return commandUpdateError;
        }

        private SqlCommand CommandError(Component componentWithError, Component componentToReplace, int idComputer, string commentary)
        {
            var commandError = new SqlCommand($"INSERT INTO Computer_Error VALUES (@{PARAM_COMPUTER},@{PARAM_COMPONENT_ERROR},@{PARAM_COMPONENT_REPLACE},@{PARAM_COMMENTARY})");
            commandError.Parameters.AddWithValue(PARAM_COMPUTER, idComputer);
            commandError.Parameters.AddWithValue(PARAM_COMPONENT_ERROR, componentWithError.Id);
            AddReplaceToCommand(componentToReplace, commandError);
            commandError.Parameters.AddWithValue(PARAM_COMMENTARY, commentary);
            return commandError;
        }

        private void AddReplaceToCommand(Component componentToReplace, SqlCommand commandError)
        {
            if (ExistsComponent(componentToReplace))
            {
                commandError.Parameters.AddWithValue(PARAM_COMPONENT_REPLACE, componentToReplace.Id);
            }
            else
            {
                //log
                commandError.Parameters.AddWithValue(PARAM_COMPONENT_REPLACE, DBNull.Value);
            }
        }

        private bool ExistsComponent(Component componentToReplace)
        {
            return componentToReplace != null;
        }
    }
}
