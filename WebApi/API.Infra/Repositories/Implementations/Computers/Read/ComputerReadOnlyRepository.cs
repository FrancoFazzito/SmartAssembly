using Application.Repositories.Interfaces;
using Domain.Computers;
using Infra.Connections;
using Infra.Repositories.Convert;
using Infra.Repositories.Implementations.Abstracts;
using System.Collections.Generic;
using System.Data;

namespace Infra.Repositories.Implementations.Computers
{
    public class ComputerReadOnlyRepository : AbstractReadOnlyRepository<Computer>, IComputerReadOnlyRepository
    {
        private readonly IComponentReadOnlyRepository componentRepository;
        private readonly ICostsReadOnlyRepository costRepo;

        public ComputerReadOnlyRepository(IConnection connection, IComponentReadOnlyRepository componentRepository, ICostsReadOnlyRepository costRepo) : base(connection)
        {
            this.componentRepository = componentRepository;
            this.costRepo = costRepo;
        }

        protected override string QuerySelectAll => "SELECT * FROM Computer";

        public IEnumerable<Computer> GetByOrder(int id)
        {
            return GetRecords("SELECT * FROM Computer where ID_Order = @id", new Dictionary<string, object>() { { "@id", id } });
        }

        protected override Computer NewRecord(IDataReader reader)
        {
            return new Computer()
            {
                Id = ConvertReader<int>.WithName(reader, "ID"),
                TypeUse = ConvertReader<string>.WithName(reader, "TypeUse"),
                Components = componentRepository.GetByComputer(ConvertReader<int>.WithName(reader, "ID")),
                Completed = ConvertReader<bool>.WithName(reader, "Completed"),
                CostBuild = costRepo.BuildCost,
                Multiplier = costRepo.PricePerfomanceMultiplier
            };
        }
    }
}