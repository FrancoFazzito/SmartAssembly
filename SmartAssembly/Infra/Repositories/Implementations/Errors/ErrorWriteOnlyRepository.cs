using Application.Repositories.Interfaces.Error;
using Domain.Components;
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
        private readonly IConnection connection;

        public ErrorWriteOnlyRepository(IConnection connection)
        {
            this.connection = connection;
        }
        public void Insert(Component componentWithError, Component componentToReplace, int idComputer, string commentary)
        {
            var commands = new List<SqlCommand>();
            var commandError = new SqlCommand($"INSERT INTO Computer_Error VALUES (@{PARAM_COMPUTER},@{PARAM_COMPONENT_ERROR},@{PARAM_COMPONENT_REPLACE},@{PARAM_COMMENTARY})");
            commandError.Parameters.AddWithValue(PARAM_COMPUTER, idComputer);
            commandError.Parameters.AddWithValue(PARAM_COMPONENT_ERROR, componentWithError.Id);
            AddReplaceToCommand(componentToReplace, commandError);
            commandError.Parameters.AddWithValue(PARAM_COMMENTARY, commentary);
            commands.Add(commandError);

            var commandUpdateError = new SqlCommand($"update [Order] set Commentary =+ @{PARAM_COMMENTARY} where ID = (select o.ID from [Order] o inner join Computer c on c.ID_Order = o.ID where c.ID = @{PARAM_COMPUTER})");
            commandUpdateError.Parameters.AddWithValue(PARAM_COMMENTARY, commentary);
            commandUpdateError.Parameters.AddWithValue(PARAM_COMPUTER, idComputer);
            commands.Add(commandUpdateError);

            if (ExistsComponent(componentToReplace))
            {
                var commandUpdateComputer = new SqlCommand($"update Component_Computer set ID_Component = @{PARAM_COMPONENT_REPLACE} where ID_Computer = @{PARAM_COMPUTER}");
                commandUpdateComputer.Parameters.AddWithValue(PARAM_COMPONENT_REPLACE, componentToReplace.Id);
                commandUpdateComputer.Parameters.AddWithValue(PARAM_COMPUTER, idComputer);
                commands.Add(commandUpdateComputer);
            }
            connection.Execute(commands);
        }

        private void AddReplaceToCommand(Component componentToReplace, SqlCommand commandError)
        {
            if (!ExistsComponent(componentToReplace))
            {
                //log
                commandError.Parameters.AddWithValue(PARAM_COMPONENT_REPLACE, DBNull.Value);
            }
            else
            {
                commandError.Parameters.AddWithValue(PARAM_COMPONENT_REPLACE, componentToReplace.Id);
            }
        }

        private bool ExistsComponent(Component componentToReplace)
        {
            return componentToReplace != null;
        }
    }
}
