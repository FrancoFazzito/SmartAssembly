using Application.Repositories.Components.Interfaces;
using Domain.Components;
using Domain.Components.Types;
using Infra.Interfaces.Connections;
using Infra.Repositories.Convert;
using Infra.Repositories.Implementations.Abstracts;
using System.Data;

namespace Infra.Repositories.Implementations.Components
{
    public class ComponentReadOnlyRepository : AbstractReadOnlyRepository<Component>, IComponentReadOnlyRepository
    {
        public ComponentReadOnlyRepository(IConnection connection) : base(connection)
        {

        }

        protected override string QuerySelectAll => "SELECT * FROM component";

        protected override string ParamName => "Name";

        protected override string QuerySelectByName => $"SELECT * FROM component WHERE name = @{ParamName}";

        protected override Component NewRecord(IDataReader reader)
        {
            return new Component
            {
                Id = ConvertReader<int>.WithName(reader, "ID"),
                Name = ConvertReader<string>.WithName(reader, ParamName),
                Price = ConvertReader<decimal>.WithName(reader, "Price"),
                PerfomanceLevel = ConvertReader<int>.WithName(reader, "Perfomance"),
                TypePart = ConvertReader<TypePart>.EnumWithName(reader, "TypePart"),
                TypeFormat = ConvertReader<TypeFormat>.EnumWithName(reader, "TypeFormat"),
                TypeMemory = ConvertReader<TypeMemory>.EnumWithName(reader, "TypeMemory"),
                Socket = ConvertReader<string>.WithName(reader, "Socket"),
                HasIntegratedVideo = ConvertReader<bool>.WithName(reader, "HasIntegratedVideo"),
                Channels = ConvertReader<int>.WithName(reader, "Channels"),
                VideoLevel = ConvertReader<int>.WithName(reader, "VideoLevel"),
                FanLevel = ConvertReader<int>.WithName(reader, "FanLevel"),
                NeedHighFrecuency = ConvertReader<bool>.WithName(reader, "NeedHighFrecuency"),
                Capacity = ConvertReader<int>.WithName(reader, "Capacity"),
                FanSize = ConvertReader<int>.WithName(reader, "FanSize"),
                MaxFrecuency = ConvertReader<int>.WithName(reader, "MaxFrecuency"),
                Stock = ConvertReader<int>.WithName(reader, "Stock"),
                Watts = ConvertReader<int>.WithName(reader, "Watts")
            };
        }
    }
}
