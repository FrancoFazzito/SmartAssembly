using System;
using System.Runtime.Serialization;

namespace Application.Common.Exceptions
{
    [Serializable]
    public class NotCompletedOrderException : Exception
    {
        public NotCompletedOrderException()
        {
        }

        public NotCompletedOrderException(string message) : base(message)
        {
        }

        public NotCompletedOrderException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected NotCompletedOrderException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }

        public override string Message => "cannot delivery this order";
    }
}