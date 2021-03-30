using System;

namespace Application.Orders.Commands.Deliver
{
    public class NotCompletedOrderException : Exception
    {
        public override string Message => "cannot delivery this order";
    }
}