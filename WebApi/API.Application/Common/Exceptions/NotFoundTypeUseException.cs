using System;
using System.Runtime.Serialization;

namespace Application.Common.Exceptions
{
    [Serializable]
    internal class NotFoundTypeUseException : Exception
    {
        public NotFoundTypeUseException()
        {
        }

        public NotFoundTypeUseException(string message) : base(message)
        {
        }

        public NotFoundTypeUseException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected NotFoundTypeUseException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}