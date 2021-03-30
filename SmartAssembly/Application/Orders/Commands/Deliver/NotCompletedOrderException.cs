using System;

namespace Application.Commands.DeliverOrders
{
    public class NotCompletedOrderException : Exception
    {
        public override string Message => "cannot delivery this order";
    }
}