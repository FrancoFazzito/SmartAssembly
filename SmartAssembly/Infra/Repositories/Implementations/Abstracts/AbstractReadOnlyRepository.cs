using Infra.Interfaces.Connections;
using System.Collections.Generic;
using System.Data;

namespace Infra.Repositories.Implementations.Abstracts
{
    public abstract class AbstractReadOnlyRepository<T> where T : class
    {
        private const string PARAM_ID = "id";
        private const string WHERE_ID = "WHERE id = @id";
        protected readonly IConnection connection;

        public IEnumerable<T> All => GetRecords(QuerySelectAll);

        protected AbstractReadOnlyRepository(IConnection connection)
        {
            this.connection = connection;
        }
        protected abstract T NewRecord(IDataReader reader);

        protected abstract string QuerySelectAll { get; }

        protected virtual string QuerySelectById => $"{QuerySelectAll} {WHERE_ID}";

        protected abstract string QuerySelectByName { get; }

        protected abstract string ParamName { get; }

        protected IEnumerable<T> GetRecords(string query, Dictionary<string, object> parameters)
        {
            using (var reader = connection.GetDataReader(query, parameters))
            {
                while (reader.Read())
                {
                    yield return NewRecord(reader);
                }
            }
        }

        protected IEnumerable<T> GetRecords(string query)
        {
            using (var reader = connection.GetDataReader(query))
            {
                while (reader.Read())
                {
                    yield return NewRecord(reader);
                }
            }
        }

        protected T GetRecord(string query, Dictionary<string, object> parameters)
        {
            using (var reader = connection.GetDataReader(query, parameters))
            {
                if (reader.Read())
                {
                    return NewRecord(reader);
                }
            }
            return null;
        }

        protected T GetRecord(string query)
        {
            using (var reader = connection.GetDataReader(query))
            {
                if (reader.Read())
                {
                    return NewRecord(reader);
                }
            }
            return null;
        }

        public T GetById(int id)
        {
            return GetRecord(QuerySelectById, new Dictionary<string, object>
            {
                { PARAM_ID, id }
            });
        }

        public T GetByName(string name)
        {
            return GetRecord(QuerySelectByName, new Dictionary<string, object>
            {
                { ParamName, name }
            });
        }
    }
}
