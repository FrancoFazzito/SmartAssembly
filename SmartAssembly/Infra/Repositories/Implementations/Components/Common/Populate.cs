using Domain.Components;
using Infra.Repositories.Convert;
using System.Data.SqlClient;

namespace Infra.Repositories.Implementations.Components
{
    public static class Populate
    {
        public static void CommandComponent(Component value, SqlCommand command)
        {
            command.Parameters.AddWithValue("id", value.Id);
            command.Parameters.AddWithValue("name", value.Name);
            command.Parameters.AddWithValue("price", value.Price);
            command.Parameters.AddWithValue("perfomance", value.PerfomanceLevel);
            command.Parameters.AddWithValue("TypePart", value.TypePart.ToString());
            command.Parameters.AddWithValue("TypeFormat", ConvertWriter.Convert(value.TypeFormat).ToString());
            command.Parameters.AddWithValue("TypeMemory", ConvertWriter.Convert(value.TypeMemory).ToString());
            command.Parameters.AddWithValue("Socket", ConvertWriter.Convert(value.Socket).ToString());
            command.Parameters.AddWithValue("HasIntegratedVideo", (bool)ConvertWriter.Convert(value.HasIntegratedVideo));
            command.Parameters.AddWithValue("Channels", (int)ConvertWriter.Convert(value.Channels));
            command.Parameters.AddWithValue("VideoLevel", (int)ConvertWriter.Convert(value.VideoLevel));
            command.Parameters.AddWithValue("FanLevel", (int)ConvertWriter.Convert(value.FanLevel));
            command.Parameters.AddWithValue("NeedHighFrecuency", (bool)ConvertWriter.Convert(value.NeedHighFrecuency));
            command.Parameters.AddWithValue("Capacity", (int)ConvertWriter.Convert(value.Capacity));
            command.Parameters.AddWithValue("FanSize", (int)ConvertWriter.Convert(value.FanSize));
            command.Parameters.AddWithValue("MaxFrecuency", (int)ConvertWriter.Convert(value.MaxFrecuency));
            command.Parameters.AddWithValue("Stock", value.Stock);
            command.Parameters.AddWithValue("Watts", value.Watts);
            command.Parameters.AddWithValue("Stock_Limit", value.StockLimit);
        }
    }
}