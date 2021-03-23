using Application.Repositories.Components.Interfaces;
using Application.Repositories.Interfaces.Computers;
using Domain.Computers;
using Infra.Interfaces.Connections;
using Infra.Repositories.Convert;
using Infra.Repositories.Implementations.Abstracts;
using System.Collections.Generic;
using System.Data;

namespace Infra.Repositories.Implementations.Computers
{
    public class ComputerReadOnlyRepository : AbstractReadOnlyRepository<Computer>, IComputerReadOnlyRepository
    {
        public ComputerReadOnlyRepository(IConnection connection, IComponentReadOnlyRepository componentRepository) : base(connection)
        {
            ComponentRepository = componentRepository;
        }

        public IComponentReadOnlyRepository ComponentRepository { get; }

        protected override string QuerySelectAll => "SELECT * FROM Computer";

        public IEnumerable<Computer> GetByOrderId(int id)
        {
            return GetRecords("SELECT * FROM Computer c inner join [Order] o on c.ID_Order = o.ID where o.ID = @id", new Dictionary<string, object>() { { "@id", id } });
        }

        protected override Computer NewRecord(IDataReader reader)
        {
            var id = ConvertReader<int>.WithName(reader, "ID");
            return new Computer()
            {
                Id = id,
                TypeUse = ConvertReader<string>.WithName(reader, "TypeUse"),
                Components = ComponentRepository.GetByComputerId(id)
            };
        }
    }
}
