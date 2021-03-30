using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace Infra.Connections
{
    public interface IConnection
    {
        string CONNECTION_NAME { get; }
        void Execute(IEnumerable<SqlCommand> commands);
        IDataReader GetDataReader(string command, Dictionary<string, object> parameters);
        IDataReader GetDataReader(string command);
    }
}