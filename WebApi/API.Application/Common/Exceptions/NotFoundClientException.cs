using System;
using System.Runtime.Serialization;

namespace Application.Common.Exceptions
{
    [Serializable]
    public class NotFoundClientException : Exception
    {
        public NotFoundClientException()
        {
        }

        public NotFoundClientException(string message) : base(message)
        {
        }

        public NotFoundClientException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected NotFoundClientException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}