using System;
using System.Runtime.Serialization;

namespace Application.Commands.DeliverOrders
{
    public class NotCompletedOrderException : Exception
    {
        public override string Message => "cannot delivery this order";
    }
}