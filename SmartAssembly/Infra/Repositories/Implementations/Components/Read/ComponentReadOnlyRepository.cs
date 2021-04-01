using Application.Repositories.Components.Interfaces;
using Domain.Components;
using Domain.Components.Types;
using Infra.Connections;
using Infra.Repositories.Convert;
using Infra.Repositories.Implementations.Abstracts;
using System.Collections.Generic;
using System.Data;

namespace Infra.Repositories.Implementations.Components
{
    public class ComponentReadOnlyRepository : AbstractReadOnlyRepository<Component>, IComponentReadOnlyRepository
    {
        public ComponentReadOnlyRepository(IConnection connection) : base(connection)
        {
        }

        protected override string QuerySelectAll => "SELECT * FROM component";

        public IEnumerable<Component> GetByComputer(int id)
        {
            return GetRecords("SELECT * from Component cmp inner join Component_Computer c on ID = c.ID_Component where c.ID_Computer = @id", new Dictionary<string, object>() { { "id", id } });
        }

        protected override Component NewRecord(IDataReader reader)
        {
            return new Component
            {
                Id = ConvertReader<int>.WithName(reader, "ID"),
                Name = ConvertReader<string>.WithName(reader, "Name"),
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
                Watts = ConvertReader<int>.WithName(reader, "Watts"),
                StockLimit = ConvertReader<int>.WithName(reader, "Stock_Limit")
            };
        }
    }
}