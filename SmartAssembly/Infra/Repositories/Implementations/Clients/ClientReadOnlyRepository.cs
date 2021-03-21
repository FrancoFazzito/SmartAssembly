using Application.Repositories.Interfaces.Clients;
using Domain.Clients;
using Infra.Interfaces.Connections;
using Infra.Repositories.Convert;
using Infra.Repositories.Implementations.Abstracts;
using System.Data;

namespace Infra.Repositories.Implementations.Clients
{
    public class ClientReadOnlyRepository : AbstractReadOnlyRepository<Client>, IClientReadOnlyRepository
    {
        public ClientReadOnlyRepository(IConnection connection) : base(connection)
        {
        }

        protected override string QuerySelectAll => "SELECT * FROM Client";

        protected override string QuerySelectByName => $"SELECT * FROM Client WHERE Email = @{ParamName}";

        protected override string ParamName => "Email";

        protected override Client NewRecord(IDataReader reader)
        {
            return new Client()
            {
                Name = ConvertReader<string>.WithName(reader, "Name"),
                Number = ConvertReader<string>.WithName(reader, "Number"),
                Email = ConvertReader<string>.WithName(reader, ParamName),
                Adress = ConvertReader<string>.WithName(reader, "Adress")
            };
        }
    }
}
