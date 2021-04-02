using System;
using System.Data;

namespace Infra.Repositories.Convert
{
    public static class ConvertReader<T>
    {
        public static T WithName(IDataReader reader, string name)
        {
            return IsNull(reader[name]) ? default : (T)reader[name];
        }

        private static bool IsNull(object value)
        {
            return DBNull.Value == value;
        }

        public static T EnumWithName(IDataReader reader, string name)
        {
            return (T)Enum.Parse(typeof(T), ConvertReader<string>.WithName(reader, name));
        }
    }
}