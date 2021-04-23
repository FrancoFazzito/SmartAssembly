using System;
using System.Runtime.Serialization;

namespace Application.Common.Exceptions
{
    [Serializable]
    public class NotAvailableComputersException : Exception
    {
        public NotAvailableComputersException()
        {
        }

        public NotAvailableComputersException(string message) : base(message)
        {
        }

        public NotAvailableComputersException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected NotAvailableComputersException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }

        public override string Message => "cannot find computers to this budget or-and use";
    }
}