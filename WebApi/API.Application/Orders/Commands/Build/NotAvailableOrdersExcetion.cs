using System;
using System.Runtime.Serialization;

namespace Application.Orders.Commands.Build
{
    [Serializable]
    public class NotAvailableOrdersExcetion : Exception
    {
        public NotAvailableOrdersExcetion()
        {
        }

        public NotAvailableOrdersExcetion(string message) : base(message)
        {
        }

        public NotAvailableOrdersExcetion(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected NotAvailableOrdersExcetion(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }

        public override string Message => "cannot find orders for this employee";
    }
}