using Infra.Connections;
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
        private string QuerySelectById => $"{QuerySelectAll} {WHERE_ID}";

        protected IEnumerable<T> GetRecords(string query, Dictionary<string, object> parameters)
        {
            var records = new List<T>();
            using (var reader = connection.GetDataReader(query, parameters))
            {
                while (reader.Read())
                {
                    records.Add(NewRecord(reader));
                }
            }
            return records;
        }

        protected IEnumerable<T> GetRecords(string query)
        {
            var records = new List<T>();
            using (var reader = connection.GetDataReader(query))
            {
                while (reader.Read())
                {
                    records.Add(NewRecord(reader));
                }
            }
            return records;
        }

        protected T GetRecord(string query, Dictionary<string, object> parameters)
        {
            T found = null;
            using (var reader = connection.GetDataReader(query, parameters))
            {
                if (reader.Read())
                {
                    found = NewRecord(reader);
                }
            }
            return found;
        }

        protected T GetRecord(string query)
        {
            T found = null;
            using (var reader = connection.GetDataReader(query))
            {
                if (reader.Read())
                {
                    found = NewRecord(reader);
                }
            }
            return found;
        }

        public T GetById(int? id)
        {
            return GetRecord(QuerySelectById, new Dictionary<string, object>
            {
                { PARAM_ID, id }
            });
        }
    }
}