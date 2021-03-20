using System.Data;

namespace Infra.Repositories.Convert
{
    public static class ConvertReader<T>
    {
        public static T WithName(IDataReader reader, string name)
        {
            return (T)reader[name];
        }

        public static T EnumWithName(IDataReader reader, string name)
        {
            return (T)System.Enum.Parse(typeof(T), ConvertReader<string>.WithName(reader, name));
        }
    }
}
