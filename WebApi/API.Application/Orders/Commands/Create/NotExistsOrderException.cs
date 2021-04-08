using System;
using System.Runtime.Serialization;

namespace Application.Orders.Commands.Create
{
    [Serializable]
    public class NotExistsOrderException : Exception
    {
        public NotExistsOrderException()
        {
        }

        public NotExistsOrderException(string message) : base(message)
        {
        }

        public NotExistsOrderException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected NotExistsOrderException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}