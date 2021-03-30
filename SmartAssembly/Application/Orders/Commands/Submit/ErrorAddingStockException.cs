using System;

namespace Application.Orders.Commands.Submit
{
    public class ErrorAddingStockException : Exception
    {
        private readonly int quantity;

        public ErrorAddingStockException(int quantity)
        {
            this.quantity = quantity;
        }

        public override string Message => $"Cannot add {quantity} computers to this order";
    }
}