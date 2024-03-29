﻿using Application.Repositories.Interfaces;
using Infra.Connections;
using System.Data.SqlClient;

namespace Infra.Repositories.Implementations.Components
{
    public class DeleteComponentRepository : IDeleteById
    {
        private readonly IConnection connection;

        public DeleteComponentRepository(IConnection connection)
        {
            this.connection = connection;
        }

        public void Delete(int? id)
        {
            var command = new SqlCommand("DELETE FROM Component WHERE ID = @id");
            command.Parameters.AddWithValue("id", id);
            connection.Execute(command);
        }
    }
}