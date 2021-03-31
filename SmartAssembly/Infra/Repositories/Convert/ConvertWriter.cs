using System;

namespace Infra.Repositories.Convert
{
    public static class ConvertWriter
    {
        public static object convert(object value) => value ?? DBNull.Value;
    }
}
