using System;
using System.Runtime.Serialization;

namespace Application.Common.Exceptions
{
    [Serializable]
    public class NotAvailableOrdersException : Exception
    {
        public NotAvailableOrdersException()
        {
        }

        public NotAvailableOrdersException(string message) : base(message)
        {
        }

        public NotAvailableOrdersException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected NotAvailableOrdersException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }

        public override string Message => "cannot find orders for this employee";
    }
}