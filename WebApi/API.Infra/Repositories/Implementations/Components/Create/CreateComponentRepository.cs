using Application.Repositories.Interfaces;
using Domain.Components;
using Infra.Connections;
using System.Data.SqlClient;

namespace Infra.Repositories.Implementations.Components
{
    public class CreateComponentRepository : ICreate<Component>
    {
        private readonly IConnection connection;

        public CreateComponentRepository(IConnection connection)
        {
            this.connection = connection;
        }

        public void Create(Component value)
        {
            var command = new SqlCommand("INSERT INTO Component VALUES (" +
                "@name," +
                "@price," +
                "@perfomance," +
                "@TypePart," +
                "@TypeFormat," +
                "@TypeMemory," +
                "@Socket," +
                "@HasIntegratedVideo," +
                "@Channels," +
                "@VideoLevel," +
                "@FanLevel," +
                "@NeedHighFrecuency," +
                "@Capacity," +
                "@FanSize," +
                "@MaxFrecuency," +
                "@Stock," +
                "@Watts," +
                "@Stock_Limit)");
            PopulateComponent.Command(value, command);
            connection.Execute(command);
        }
    }
}