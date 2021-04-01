using Application.Repositories.Interfaces;
using Domain.Components;
using Infra.Connections;
using System.Data.SqlClient;

namespace Infra.Repositories.Implementations.Components
{
    public class UpdateComponentRepository : IUpdate<Component>
    {
        private readonly IConnection connection;

        public UpdateComponentRepository(IConnection connection)
        {
            this.connection = connection;
        }

        public void Update(Component value)
        {
            var command = new SqlCommand("UPDATE Component SET " +
                "Name = @name, " +
                "Price = @price, " +
                "perfomance = @perfomance, " +
                "TypePart = @TypePart, " +
                "TypeFormat = @TypeFormat, " +
                "TypeMemory = @TypeMemory, " +
                "Socket = @Socket, " +
                "HasIntegratedVideo = @HasIntegratedVideo, " +
                "Channels = @Channels, " +
                "VideoLevel = @VideoLevel, " +
                "FanLevel = @FanLevel," +
                "NeedHighFrecuency = @NeedHighFrecuency," +
                "Capacity = @Capacity," +
                "FanSize = @FanSize," +
                "MaxFrecuency = @MaxFrecuency," +
                "Stock = @Stock," +
                "Watts = @Watts," +
                "Stock_Limit = @Stock_Limit WHERE ID = @id");
            Populate.CommandComponent(value, command);
            connection.Execute(command);
        }
    }
}