﻿using Application.Repositories.Interfaces;
using Domain.Components;
using Infra.Connections;
using Infra.Repositories.Convert;
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

        public void Update(Component component)
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
            command.Parameters.AddWithValue("name",component.Name);
            command.Parameters.AddWithValue("price",component.Price);
            command.Parameters.AddWithValue("perfomance",component.PerfomanceLevel);
            command.Parameters.AddWithValue("TypePart",component.TypePart.ToString());
            command.Parameters.AddWithValue("TypeFormat",ConvertWriter.convert(component.TypeFormat).ToString());
            command.Parameters.AddWithValue("TypeMemory",ConvertWriter.convert(component.TypeMemory).ToString());
            command.Parameters.AddWithValue("Socket",ConvertWriter.convert(component.Socket).ToString());
            command.Parameters.AddWithValue("HasIntegratedVideo",(bool)ConvertWriter.convert(component.HasIntegratedVideo));
            command.Parameters.AddWithValue("Channels",(int)ConvertWriter.convert(component.Channels));
            command.Parameters.AddWithValue("VideoLevel",(int)ConvertWriter.convert(component.VideoLevel));
            command.Parameters.AddWithValue("FanLevel",(int)ConvertWriter.convert(component.FanLevel));
            command.Parameters.AddWithValue("NeedHighFrecuency",(bool)ConvertWriter.convert(component.NeedHighFrecuency));
            command.Parameters.AddWithValue("Capacity",(int)ConvertWriter.convert(component.Capacity));
            command.Parameters.AddWithValue("FanSize",(int)ConvertWriter.convert(component.FanSize));
            command.Parameters.AddWithValue("MaxFrecuency",(int)ConvertWriter.convert(component.MaxFrecuency));
            command.Parameters.AddWithValue("Stock",component.Stock);
            command.Parameters.AddWithValue("Watts",component.Watts);
            command.Parameters.AddWithValue("Stock_Limit",component.StockLimit);
            command.Parameters.AddWithValue("id",component.Id);
            connection.Execute(command);
        }
    }
}
