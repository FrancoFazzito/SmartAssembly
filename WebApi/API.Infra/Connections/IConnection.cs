using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace Infra.Connections
{
    public interface IConnection
    {
        void Execute(IEnumerable<SqlCommand> commands);

        void Execute(SqlCommand command);

        IDataReader GetDataReader(string command, Dictionary<string, object> parameters);

        IDataReader GetDataReader(string command);
    }
}