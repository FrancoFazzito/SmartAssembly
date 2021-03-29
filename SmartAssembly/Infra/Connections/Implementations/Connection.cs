﻿using Infra.Interfaces.Connections;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace Infra.Implementations.Connections
{
    public class Connection : IConnection
    {
        private readonly SqlConnection connection;

        public Connection()
        {
            connection = new SqlConnection(ConfigurationManager.ConnectionStrings[CONNECTION_NAME].ConnectionString);
        }

        private SqlConnection Open()
        {
            if (connection.State != ConnectionState.Open)
            {
                connection.Open();
            }
            return connection;
        }

        public void Execute(IEnumerable<SqlCommand> commands)
        {
            connection.Open();
            using (var transaction = connection.BeginTransaction())
            {
                foreach (var command in commands)
                {
                    command.Connection = connection;
                    command.Transaction = transaction;
                }
                try
                {
                    foreach (var command in commands)
                    {
                        command.ExecuteNonQuery();
                    }
                    transaction.Commit();
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    throw new Exception(ex.Message);
                }
                finally { connection.Close(); }
            }
        }

        public IDataReader GetDataReader(string command)
        {
            using (var sqlCommand = new SqlCommand(command, Open()))
            {
                return sqlCommand.ExecuteReader();
            }
        }

        public IDataReader GetDataReader(string command, Dictionary<string, object> parameters)
        {
            using (var sqlCommand = new SqlCommand(command, Open()))
            {
                foreach (var param in parameters)
                {
                    sqlCommand.Parameters.AddWithValue(param.Key, param.Value);
                }
                return sqlCommand.ExecuteReader();
            }
        }

        public string CONNECTION_NAME => "Main";
    }
}