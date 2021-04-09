using System;
using System.Runtime.Serialization;

namespace Application.Orders.Commands.RegisterError
{
    [Serializable]
    public class NotFoundComponentException : Exception
    {
        public NotFoundComponentException()
        {
        }

        public NotFoundComponentException(string message) : base(message)
        {
        }

        public NotFoundComponentException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected NotFoundComponentException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}