using Domain.Components;
using Infra.Repositories.Convert;
using System.Data.SqlClient;

namespace Infra.Repositories.Implementations.Components
{
    public static class PopulateComponent
    {
        public static void Command(Component component, SqlCommand command)
        {
            command.Parameters.AddWithValue("id", component.Id);
            command.Parameters.AddWithValue("name", component.Name);
            command.Parameters.AddWithValue("price", component.Price);
            command.Parameters.AddWithValue("perfomance", component.PerfomanceLevel);
            command.Parameters.AddWithValue("TypePart", component.TypePart.ToString());
            command.Parameters.AddWithValue("TypeFormat", ConvertWriter.Convert(component.TypeFormat).ToString());
            command.Parameters.AddWithValue("TypeMemory", ConvertWriter.Convert(component.TypeMemory).ToString());
            command.Parameters.AddWithValue("Socket", ConvertWriter.Convert(component.Socket).ToString());
            command.Parameters.AddWithValue("HasIntegratedVideo", (bool)ConvertWriter.Convert(component.HasIntegratedVideo));
            command.Parameters.AddWithValue("Channels", (int)ConvertWriter.Convert(component.Channels));
            command.Parameters.AddWithValue("VideoLevel", (int)ConvertWriter.Convert(component.VideoLevel));
            command.Parameters.AddWithValue("FanLevel", (int)ConvertWriter.Convert(component.FanLevel));
            command.Parameters.AddWithValue("NeedHighFrecuency", (bool)ConvertWriter.Convert(component.NeedHighFrecuency));
            command.Parameters.AddWithValue("Capacity", (int)ConvertWriter.Convert(component.Capacity));
            command.Parameters.AddWithValue("FanSize", (int)ConvertWriter.Convert(component.FanSize));
            command.Parameters.AddWithValue("MaxFrecuency", (int)ConvertWriter.Convert(component.MaxFrecuency));
            command.Parameters.AddWithValue("Stock", component.Stock);
            command.Parameters.AddWithValue("Watts", component.Watts);
            command.Parameters.AddWithValue("Stock_Limit", component.StockLimit);
        }
    }
}