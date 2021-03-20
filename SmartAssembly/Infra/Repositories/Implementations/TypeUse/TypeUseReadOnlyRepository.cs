using Application.Commands.Build.Specifications;
using Application.Repositories.TypeUses.Interfaces;
using Infra.Interfaces.Connections;
using Infra.Repositories.Convert;
using Infra.Repositories.Implementations.Abstracts;
using System.Data;

namespace Infra.Repositories.Implementations.TypeUses
{
    public class TypeUseReadOnlyRepository : AbstractReadOnlyRepository<ISpecification>, ITypeUseReadOnlyRepository
    {
        public TypeUseReadOnlyRepository(IConnection connection) : base(connection)
        {
        }

        protected override string QuerySelectAll => "SELECT * FROM TypeUse";

        protected override string QuerySelectByName => $"SELECT * FROM TypeUse where Name = @{ParamName}";

        protected override string ParamName => "Name";

        protected override ISpecification NewRecord(IDataReader reader) //corregir namespaces
        {
            return new Specification(ConvertReader<int>.WithName(reader, "Cpu"),
                                     ConvertReader<int>.WithName(reader, "Fan"),
                                     ConvertReader<int>.WithName(reader, "Ram"),
                                     ConvertReader<int>.WithName(reader, "Gpu"),
                                     ConvertReader<int>.WithName(reader, "HDD"),
                                     ConvertReader<int>.WithName(reader, "SSD"),
                                     ConvertReader<TypeUse>.EnumWithName(reader, ParamName));
        }
    }
}
