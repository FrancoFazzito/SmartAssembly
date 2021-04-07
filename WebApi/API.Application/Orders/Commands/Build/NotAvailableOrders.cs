using System;
using System.Runtime.Serialization;

namespace Application.Orders.Commands.Build
{
    [Serializable]
    public class NotAvailableOrders : Exception
    {
        public NotAvailableOrders()
        {
        }

        public NotAvailableOrders(string message) : base(message)
        {
        }

        public NotAvailableOrders(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected NotAvailableOrders(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }

        public override string Message => "cannot find orders for this employee";
    }
}