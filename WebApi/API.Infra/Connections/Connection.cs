using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace Infra.Connections
{
    public class Connection : IConnection
    {
        private readonly SqlConnection connection;

        public Connection(string connectionString)
        {
            connection = new SqlConnection(connectionString);
        }

        private SqlConnection Open()
        {
            if (connection.State != ConnectionState.Open)
            {
                connection.Open();
            }
            return connection;
        }

        public void Execute(SqlCommand command)
        {
            command.Connection = Open();
            command.Transaction = Transaction();
            try
            {
                command.ExecuteNonQuery();
                command.Transaction.Commit();
            }
            catch
            {
                command.Transaction.Rollback();
            }
            Close();
        }

        public void Execute(IEnumerable<SqlCommand> commands)
        {
            Open();
            using (var transaction = Transaction())
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
                catch
                {
                    transaction.Rollback();
                }
                finally { Close(); }
            }
        }

        private SqlTransaction Transaction()
        {
            return connection.BeginTransaction();
        }

        private void Close()
        {
            connection.Close();
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

        public string Name => "Main";
    }
}