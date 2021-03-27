using System;

namespace Application.Commands.BuildComputers.Orders
{
    public class ErrorStockException : Exception
    {
        private readonly int quantity;

        public ErrorStockException(int quantity)
        {
            this.quantity = quantity;
        }

        public override string Message => $"Cannot add {quantity} computers to this order";
    }
}