using System;

namespace Infra.Repositories.Convert
{
    public static class ConvertWriter
    {
        public static object Convert(object value)
        {
            return value ?? DBNull.Value;
        }
    }
}