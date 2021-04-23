using System;
using System.Runtime.Serialization;

namespace Application.Common.Exceptions
{
    [Serializable]
    public class NotFoundOrderException : Exception
    {
        public NotFoundOrderException()
        {
        }

        public NotFoundOrderException(string message) : base(message)
        {
        }

        public NotFoundOrderException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected NotFoundOrderException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}