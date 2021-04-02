using System;
using System.Runtime.Serialization;

namespace Application.Orders.Commands.Create
{
    [Serializable]
    internal class NotExistClientException : Exception
    {
        public NotExistClientException()
        {
        }

        public NotExistClientException(string message) : base(message)
        {
        }

        public NotExistClientException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected NotExistClientException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}