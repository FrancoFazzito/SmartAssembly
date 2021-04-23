using System;
using System.Runtime.Serialization;

namespace Application.Common.Exceptions
{
    [Serializable]
    public class NotFoundCostException : Exception
    {
        public NotFoundCostException()
        {
        }

        public NotFoundCostException(string message) : base(message)
        {
        }

        public NotFoundCostException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected NotFoundCostException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}