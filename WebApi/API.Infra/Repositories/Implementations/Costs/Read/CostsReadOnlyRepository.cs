using Application.Repositories.Interfaces;
using Infra.Connections;
using Infra.Repositories.Implementations.Abstracts;
using System;
using System.Data;
using System.Linq;

namespace Infra.Repositories.Implementations.Costs.Read
{
    public class CostsReadOnlyRepository : AbstractReadOnlyRepository<Tuple<string, int>>, ICostsReadOnlyRepository
    {
        private const string PARAM_BUILD = "Build";
        private const string PARAM_MULTIPLIER = "Multiplier";

        public CostsReadOnlyRepository(IConnection connection) : base(connection)
        {
        }

        public int BuildCost => All.FirstOrDefault(c => c.Item1 == PARAM_BUILD).Item2;

        public int PricePerfomanceMultiplier => All.FirstOrDefault(c => c.Item1 == PARAM_MULTIPLIER).Item2;

        protected override string QuerySelectAll => "SELECT * FROM Cost";

        protected override Tuple<string, int> NewRecord(IDataReader reader)
        {
            return new Tuple<string, int>(reader.GetString(0), reader.GetInt32(1));
        }
    }
}