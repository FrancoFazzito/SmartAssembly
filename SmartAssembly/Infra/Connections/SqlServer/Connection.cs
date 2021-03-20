using Infra.Interfaces.Connections;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace Infra.SqlServer.Connections
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

        private void Close()
        {
            connection.Close();
        }

        //public void Execute(string command, Dictionary<string, object> parameters)
        //{
        //    try
        //    {
        //        using (var sqlCommand = new SqlCommand(command, Open()))
        //        {
        //            foreach (var param in parameters)
        //            {
        //                sqlCommand.Parameters.AddWithValue(param.Key, param.Value);
        //            }
        //            sqlCommand.ExecuteNonQuery();
        //        }
        //    }
        //    finally { Close(); }
        //}

        public void Execute(IEnumerable<SqlCommand> commands)
        {
            using (var transaction = connection.BeginTransaction())
            {
                foreach (var command in commands)
                {
                    command.Connection = Open();
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
                catch
                {
                    transaction.Rollback();
                }
                finally { Close(); }
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
