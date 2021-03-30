using Application.Repositories.Interfaces.Clients;
using Domain.Clients;
using Infra.Connections;
using Infra.Repositories.Convert;
using Infra.Repositories.Implementations.Abstracts;
using System.Data;
using System.Linq;

namespace Infra.Repositories.Implementations.Clients
{
    public class ClientReadOnlyRepository : AbstractReadOnlyRepository<Client>, IClientReadOnlyRepository
    {
        public ClientReadOnlyRepository(IConnection connection) : base(connection)
        {
        }

        protected override string QuerySelectAll => "SELECT * FROM Client";

        public Client GetByEmail(string email)
        {
            return All.FirstOrDefault(c => c.Email == email);
        }

        protected override Client NewRecord(IDataReader reader)
        {
            return new Client()
            {
                Name = ConvertReader<string>.WithName(reader, "Name"),
                Number = ConvertReader<string>.WithName(reader, "Number"),
                Email = ConvertReader<string>.WithName(reader, "Email"),
                Adress = ConvertReader<string>.WithName(reader, "Adress")
            };
        }
    }
}
